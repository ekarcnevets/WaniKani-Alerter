using System;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WaniKaniClientLib.Models;

namespace WaniKaniAlerter
{
    public partial class frmMain : Form
    {
        private AsyncClient _client;
        private StudyQueue queue;
        private bool SilentMode = false;

        public Task Initialize(bool newKey = false) {
            string apiKey;
            if (newKey || String.IsNullOrWhiteSpace(WaniKaniAlerter.Properties.Settings.Default.ApiKey)) {
                apiKey = EditAPIKey();
            } else {
                apiKey = WaniKaniAlerter.Properties.Settings.Default.ApiKey;
            }
            _client = new AsyncClient(apiKey, 15);
            return ValidateAPIKey();
        }

        private void Alert(int numReviews) {
            if (!SilentMode) {
                ni.ShowBalloonTip(5000
                                 , "WaniKani Alert"
                                 , String.Format("The Crabigator has {0:N} reviews for you.", numReviews)
                                 , ToolTipIcon.None);
                SystemSounds.Exclamation.Play();
            }
        }

        public string EditAPIKey() {
            string apiKey = Interaction.InputBox("Please enter your API key: ", "Set WaniKani API Key", WaniKaniAlerter.Properties.Settings.Default.ApiKey);

            WaniKaniAlerter.Properties.Settings.Default.ApiKey = apiKey;
            WaniKaniAlerter.Properties.Settings.Default.Save();

            return apiKey;
        }

        public void RefreshQueue(bool forceUpdate = false) {
            _client.StudyQueue(!forceUpdate).ContinueWith(async (t) => {
                queue = await t;
                if (queue.ReviewsAvailable >= WaniKaniAlerter.Properties.Settings.Default.MinimumReviews) {
                    Alert(queue.ReviewsAvailable);
                }
                UpdateStatus(queue.ReviewsAvailable);
            });
        }

        private void StartListening() {
            RefreshQueue();
            timerUpdate.Start();
        }

        private void StopListening() {
            timerUpdate.Stop();
        }

        private void UpdateStatus(string newStatus) {
            statusToolStripMenuItem.Text = newStatus;
        }

        private void UpdateStatus(int reviewsAvailable) {
            UpdateStatus(String.Format("{0:N0} review(s) available", reviewsAvailable));
        }

        public Task ValidateAPIKey() {
            return _client.UserInformation().ContinueWith(async (t) => {
                UpdateStatus("Validating API key...");
                var info = await t;
                if (info == null) {
                    // Assume user does not exist.  Also possible: network errors, for example
                    var result = MessageBox.Show(WaniKaniAlerter.Properties.Resources.UserInfoRetrievalFailed
                                                , WaniKaniAlerter.Properties.Resources.ErrorMsgBoxTitle
                                                , MessageBoxButtons.YesNo
                                                , MessageBoxIcon.Error);
                    if (result == DialogResult.Yes) {
                        // Intentionally left without 'await'
                        #pragma warning disable 4014
                        Initialize(true);
                        #pragma warning restore 4014
                    } else {
                        Application.Exit();
                    }

                    // Even if the user sets a correct API key following this, it will be
                    // handled in the nested ValidateAPIKey call, so do nothing more here.
                } else {
                    UpdateStatus("Getting info...");
                    StartListening();
                }
            });
        }

        #region UI Event Handlers
        private void changeAPIKeyToolStripMenuItem_Click(object sender, EventArgs e) {
            StopListening();
            Initialize();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dlg = this.ShowDialog();
            if (dlg == System.Windows.Forms.DialogResult.OK) {
                WaniKaniAlerter.Properties.Settings.Default.MinimumReviews = (int) this.nudMinReviews.Value;
                WaniKaniAlerter.Properties.Settings.Default.Save();
            } else {
                this.nudMinReviews.Value = WaniKaniAlerter.Properties.Settings.Default.MinimumReviews;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void timerUpdate_Tick(object sender, EventArgs e) {
            RefreshQueue();
        }

        private void updateNowToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshQueue(true);
        }

        private void silentModeToolStripMenuItem_Click(object sender, EventArgs e) {
            var self = (ToolStripMenuItem)sender;
            SilentMode = !SilentMode;
            self.Checked = SilentMode;
        }
        #endregion

        #region Constructors
        public frmMain() {
            InitializeComponent();
            this.Icon = WaniKaniAlerter.Properties.Resources.LogoStamp;
            this.ni.Icon = WaniKaniAlerter.Properties.Resources.LogoStamp;
        }
        #endregion
    }
}
