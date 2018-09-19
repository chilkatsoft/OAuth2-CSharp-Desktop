using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAuth2
    {
    public partial class Form1 : Form
        {
        private Chilkat.OAuth2 m_oauth2 = null;

        const string facebookAuthEndpoint = "https://www.facebook.com/dialog/oauth";
        const string facebookTokenEndpoint = "https://graph.facebook.com/oauth/access_token";
        const string googleAuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string googleTokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";
        const string linkedinAuthEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
        const string linkedinTokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
        const string salesForceAuthEndpoint = "https://login.salesforce.com/services/oauth2/authorize";
        const string salesForceTokenEndpoint = "https://login.salesforce.com/services/oauth2/token";
        const string gitAuthEndpoint = "https://github.com/login/oauth/authorize";
        const string gitTokenEndpoint = "https://github.com/login/oauth/access_token";
        const string msGraphAuthEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";
        const string msGraphTokenEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/token";

        // Replace these with actual values.
        const string facebookClientId = "FACEBOOK-CLIENT-ID";
        const string facebookClientSecret = "FACEBOOK-CLIENT-SECRET";

        const string googleAppClientId = "GOOGLE-CLIENT-ID";
        const string googleAppClientSecret = "GOOGLE-CLIENT-SECRET";

        const string linkedinClientId = "LINKEDIN-CLIENT-ID";
        const string linkedinClientSecret = "LINKEDIN-CLIENT-SECRET";

        const string salesForceClientId = "SALESFORCE-CLIENT-ID";
        const string salesForceClientSecret = "SALESFORCE-CLIENT-SECRET";

        const string gitClientId = "GITHUB-CLIENT-ID";
        const string gitClientSecret = "GITHUB-CLIENT-SECRET";

        const string msGraphClientId = "MSGRAPH-CLIENT-ID";
        const string msGraphClientSecret = "MSGRAPH-CLIENT-SECRET";


        public Form1()
            {
            InitializeComponent();
            }

        // When we're in a background thread, we should update UI elements in the foreground thread.
        private void fgAppendToLog(string s)
            {
            this.Invoke((MethodInvoker)delegate
            {
                textBox1.Text += s;
            });
            }

        private void fgSetAccessToken(string s)
            {
            this.Invoke((MethodInvoker)delegate
            {
                txtAccessToken.Text = s;
            });
            }

        private void fgSetRefreshToken(string s)
            {
            this.Invoke((MethodInvoker)delegate
            {
                txtRefreshToken.Text = s;
            });
            }

        // Remember that TaskCompleted runs in a background thread.
        // We cannot just update UI elements directly..
        void oauth2_OnTaskCompleted(object sender, Chilkat.TaskCompletedEventArgs args)
            {
            fgAppendToLog("Task Completed.  Flow state = " + m_oauth2.AuthFlowState.ToString() + "\r\n");

            if (m_oauth2.AuthFlowState == 3)
                {
                // Success!
                fgSetAccessToken(m_oauth2.AccessToken);

                // Some providers, such as Facebook, do not provide a refresh token (and thus RefreshToken will be empty).
                fgSetRefreshToken(m_oauth2.RefreshToken);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Access Granted");
                sb.AppendLine(m_oauth2.AccessTokenResponse);
                fgAppendToLog(sb.ToString());

                }
            else if (m_oauth2.AuthFlowState == 4)
                {
                // Access Denied.  The user interactive choose to deny access (in the browser) rather than click on the "Allow" button.
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Access Denied");
                sb.AppendLine(m_oauth2.AccessTokenResponse);
                fgAppendToLog(sb.ToString());
                }
            else
                {
                // Some other error happened and the OAuth2 did not complete.
                fgAppendToLog(m_oauth2.FailureInfo);
                }
            }

        private void do_oauth2(OAuth2Params p, bool bCodeChallenge = true)
            {
            Chilkat.OAuth2 oauth2 = new Chilkat.OAuth2();

            oauth2.ListenPort = p.ListenPort;

            oauth2.AuthorizationEndpoint = p.AuthorizationEndpoint;
            oauth2.TokenEndpoint = p.TokenEndpoint;
            oauth2.ClientId = p.ClientId;
            oauth2.ClientSecret = p.ClientSecret;
            oauth2.CodeChallenge = bCodeChallenge;
            if (bCodeChallenge)
                {
                oauth2.CodeChallengeMethod = "S256";
                }
            if ((p.Scope != null) && (p.Scope.Length > 0)) oauth2.Scope = p.Scope;

            // Begin the OAuth2 flow.  Returns a URL that should be loaded in a browser.
            string url = oauth2.StartAuth();
            if (url == null)
                {
                textBox1.Text = oauth2.LastErrorText;
                MessageBox.Show("StartAuth failed.");
                return;
                }

            m_oauth2 = oauth2;

            // Start a web browser and load the url.
            // This is where the end-user should accept or deny the authorization request.
            System.Diagnostics.Process.Start(url);

            // Monitor for the OAuth2 completion.
            m_oauth2.OnTaskCompleted += oauth2_OnTaskCompleted;
            Chilkat.Task task = m_oauth2.MonitorAsync();
            if (task == null)
                {
                MessageBox.Show("Failed to start monitoring.");
                return;
                }

            // Start the task.
            // oauth2_OnTaskCompleted will be called when the end-user responds from the browser.
            task.Run();

            // We're done with the .NET task object.
            // The underlying (internal) Chilkat task is running in a background thread.
            // Disposing of the .NET object does not affect the task that is running.
            // It is important to dispose of .NET's reference to the underlying object so that
            // when the task does complete, it is deallocated.  Otherwise, a reference
            // to the underlying task remains and would only get removed when .NET
            // garbage collects.
            task.Dispose();
            task = null;

            return;
            }

        private void clearTextBoxes()
            {
            textBox1.Text = "";
            txtAccessToken.Text = "";
            txtRefreshToken.Text = "";
            }

        private void disposeOldOAuth2()
            {
            // If the m_oauth2 exists from a previous OAuth2 authorization,
            // make sure it is disposed.
            if (m_oauth2 != null)
                {
                m_oauth2.Dispose();
                m_oauth2 = null;
                }
            }

        private void Form1_Load(object sender, EventArgs e)
            {
            Chilkat.Global glob = new Chilkat.Global();
            if (!glob.UnlockBundle("Anything for 30-day trial"))
                {
                MessageBox.Show("Failed to unlock Chilkat.");
                textBox1.Text = glob.LastErrorText;
                }

            }

        private void btnFacebook_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            // This matches the Site URL configured for our Facebook APP, which is "http://localhost:3017/"
            p.ListenPort = Convert.ToInt32(txtListenPort.Text);
            p.AuthorizationEndpoint = facebookAuthEndpoint;
            p.TokenEndpoint = facebookTokenEndpoint;
            p.ClientId = facebookClientId;
            p.ClientSecret = facebookClientSecret;

            // Set the Scope to a comma-separated list of permissions the app wishes to request.
            // See https://developers.facebook.com/docs/facebook-login/permissions/ for a full list of permissions.
            p.Scope = "public_profile,user_friends,email,user_posts,user_likes,user_photos";

            do_oauth2(p);

            return;
            }

        private void btnGoogle_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            p.ListenPort = 0;
            p.AuthorizationEndpoint = googleAuthorizationEndpoint;
            p.TokenEndpoint = googleTokenEndpoint;
            p.ClientId = googleAppClientId;
            p.ClientSecret = googleAppClientSecret;

            // This is the scope for Google Drive.
            // See https://developers.google.com/identity/protocols/googlescopes
            p.Scope = "https://www.googleapis.com/auth/drive";

            do_oauth2(p);

            return;
            }

        private void btnLinkedIn_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            // This should match the Authorized Redirect URL in your LinkedIn app, which would look like "http://localhost:3017/"
            p.ListenPort = Convert.ToInt32(txtListenPort.Text);
            p.AuthorizationEndpoint = linkedinAuthEndpoint;
            p.TokenEndpoint = linkedinTokenEndpoint;
            p.ClientId = linkedinClientId;
            p.ClientSecret = linkedinClientSecret;
            do_oauth2(p,false);

            return;
            }

        private void btnSalesForce_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            p.ListenPort = Convert.ToInt32(txtListenPort.Text);
            p.AuthorizationEndpoint = salesForceAuthEndpoint;
            p.TokenEndpoint = salesForceTokenEndpoint;
            p.ClientId = salesForceClientId;
            p.ClientSecret = salesForceClientSecret;
            do_oauth2(p);

            return;
            }

        private void btnGitHub_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            p.ListenPort = Convert.ToInt32(txtListenPort.Text);
            p.AuthorizationEndpoint = gitAuthEndpoint;
            p.TokenEndpoint = gitTokenEndpoint;
            p.ClientId = gitClientId;
            p.ClientSecret = gitClientSecret;
            do_oauth2(p);

            return;
            }

        private void btnMsGraph_Click(object sender, EventArgs e)
            {
            clearTextBoxes();
            disposeOldOAuth2();

            OAuth2Params p = new OAuth2Params();

            p.ListenPort = Convert.ToInt32(txtListenPort.Text);
            p.AuthorizationEndpoint = msGraphAuthEndpoint;
            p.TokenEndpoint = msGraphTokenEndpoint;
            p.ClientId = msGraphClientId;
            p.ClientSecret = msGraphClientSecret;
            p.Scope = "openid profile offline_access user.readwrite mail.readwrite mail.send files.readwrite";
            do_oauth2(p);
            }


        }
    }
