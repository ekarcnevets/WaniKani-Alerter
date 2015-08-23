using System;
using System.Collections.Concurrent;
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
        private DateTime NextReviewTimeWhenAlertSeen;
        private ConcurrentQueue<Action> messages = new ConcurrentQueue<Action>();

        public Task Initialize(bool newKey = false) {
            string apiKey;
            if (newKey || String.IsNullOrWhiteSpace(WaniKaniAlerter.Properties.Settings.Default.ApiKey)) {
                apiKey = EditAPIKey();
                if (String.IsNullOrWhiteSpace(apiKey)) {
                    // No key entered: exit now.
                    Application.Exit();
                }
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
                                 , String.Format("The Crabigator has {0:N0} reviews for you.", numReviews)
                                 , ToolTipIcon.None);
                SystemSounds.Exclamation.Play();
            }
        }

        public string EditAPIKey() {
            string apiKey = WaniKaniAlerter.Properties.Settings.Default.ApiKey;
            string newKey = Interaction.InputBox("Please enter your API key: ", "Set WaniKani API Key", apiKey);

            // If the input box was not cancelled
            if (!String.IsNullOrEmpty(newKey)) {
                WaniKaniAlerter.Properties.Settings.Default.ApiKey = newKey;
                WaniKaniAlerter.Properties.Settings.Default.Save();
                apiKey = newKey;
            }

            return apiKey;
        }

        public void RefreshQueue(bool forceUpdate = false) {
            UpdateStatus("Getting info...");
            _client.StudyQueue(!forceUpdate).ContinueWith(async (t) => {
                queue = await t;
                // Don't notify repeatedly if the first notification was seen.
                if (NextReviewTimeWhenAlertSeen != queue.NextReviewDate && queue.ReviewsAvailable >= WaniKaniAlerter.Properties.Settings.Default.MinimumReviews) {
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
            messages.Enqueue(() => statusToolStripMenuItem.Text = newStatus);
        }

        private void UpdateStatus(int reviewsAvailable) {
            UpdateStatus(String.Format("{0:N0} review(s) available", reviewsAvailable));
        }

        public Task ValidateAPIKey() {
            UpdateStatus("Validating API key...");
            return _client.UserInformation().ContinueWith(async (t) => {
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
                WaniKaniAlerter.Properties.Settings.Default.UpdateRate = (int)this.nudUpdateRate.Value;
                timerUpdate.Interval = (int) this.nudUpdateRate.Value * 60000;
                WaniKaniAlerter.Properties.Settings.Default.Save();
            } else {
                this.nudMinReviews.Value = WaniKaniAlerter.Properties.Settings.Default.MinimumReviews;
                this.nudUpdateRate.Value = WaniKaniAlerter.Properties.Settings.Default.UpdateRate;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void timerHandleMessages_Tick(object sender, EventArgs e) {
            Action message;
            while (messages.TryDequeue(out message)) {
                message();
            }
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

        private void ni_BalloonTipClicked(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.wanikani.com/dashboard");
            NextReviewTimeWhenAlertSeen = queue.NextReviewDate;
        }
        #endregion

        #region Constructors
        public frmMain() {
            InitializeComponent();

            // Disable resize at runtime but not in the designer
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.Icon = WaniKaniAlerter.Properties.Resources.LogoStamp;
            this.ni.Icon = WaniKaniAlerter.Properties.Resources.LogoStamp;

            // Load user settings that affect controls
            this.timerUpdate.Interval = WaniKaniAlerter.Properties.Settings.Default.UpdateRate * 60000;

            this.nudMinReviews.Value = WaniKaniAlerter.Properties.Settings.Default.MinimumReviews;
            this.nudUpdateRate.Value = WaniKaniAlerter.Properties.Settings.Default.UpdateRate;
        }
        #endregion
    }
}
