using System.Windows.Forms;

namespace spoofer.pro.GUI.Notification
{
    public partial class BoxMessage : Form
    {
        public BoxMessage()
        {
            InitializeComponent();
        }
        public static string message;
        public static string title;
        private void BoxMessage_Load(object sender, System.EventArgs e)
        {
            messageLbl.Text = message;
            titleLbl.Text = title;
            this.Refresh();
            Clear();
        }
        public async static void Clear()
        {
            message = string.Empty;
            title = string.Empty;
        }
        private async void siticoneShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void materialButton3_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this.Close();
            Clear();
        }

        private async void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
