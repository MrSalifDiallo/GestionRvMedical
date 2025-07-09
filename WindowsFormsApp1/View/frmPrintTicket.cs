using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using QRCoder;
using System;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Report;
using WindowsFormsApp1.View.Api;

namespace WindowsFormsApp1.View
{
    public partial class frmPrintTicket : Form
    {
        private readonly Patient patientInfos;
        private readonly InfosRendezVous infos;
        private string fileName;
        private string urlPdf;
        private byte[] qrImage;
        private readonly Utils logger = new Utils();

        public frmPrintTicket(Patient patientInfos, InfosRendezVous infos)
        {
            InitializeComponent();
            this.patientInfos = patientInfos;
            this.infos = infos;
            this.Load += frmPrintTicket_Load; // Exécute le code au chargement du formulaire
        }

        private async void frmPrintTicket_Load(object sender, EventArgs e)
        {
            try
            {
                fileName = $"ticket_{patientInfos.IdU}_{DateTime.Now:yyyy_MM_dd_HHmmss}.pdf";
                urlPdf = BuildPdfUrl(fileName);
                qrImage = GenerateQrCode(urlPdf);

                GeneratePdfReport();

                // Afficher le ticket dans CrystalReportViewer
                var ticket = new rptTicketRv();
                ticket.SetDataSource(GetTicketTable());
                crystalReportViewer1.ReportSource = ticket;
                crystalReportViewer1.Refresh();

                MessageBox.Show($"Votre ticket est accessible ici :\n{urlPdf}", "PDF prêt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Envoi du message WhatsApp
/*                await SendConfirmationMessageAsync();
*/            }
            catch (Exception ex)
            {
                logger.WriteDataError("frmPrintTicket_Load", ex.ToString());
                MessageBox.Show("Erreur lors du chargement du ticket.\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildPdfUrl(string filename)
        {
            string baseUrl = ConfigurationManager.AppSettings["ServeurApiPDF"];
            return $"{baseUrl}/{filename}";
        }

        private byte[] GenerateQrCode(string content)
        {
            using (var ms = new MemoryStream())
            {
                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                var bitmap = qrCode.GetGraphic(20);
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void GeneratePdfReport()
        {
            try
            {
                var rpt = new rptTicketRv();
                rpt.SetDataSource(GetTicketTable());

                string folder = Path.Combine(Application.StartupPath, "TicketsPDF");
                Directory.CreateDirectory(folder);

                string fullPath = Path.Combine(folder, fileName);
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fullPath);
            }
            catch (Exception ex)
            {
                logger.WriteDataError("GeneratePdfReport", ex.ToString());
                MessageBox.Show($"Erreur génération PDF : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetTicketTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("NomPrenom");
            dt.Columns.Add("DateNaissance");
            dt.Columns.Add("DateRv");
            dt.Columns.Add("HeureRv");
            dt.Columns.Add("Medecin");
            dt.Columns.Add("DataQr", typeof(byte[]));

            dt.Rows.Add(
                patientInfos.NomPrenom,
                patientInfos.DateNaissance?.ToString("dd/MM/yyyy") ?? "Inconnue",
                infos.DateRv.ToString("dd/MM/yyyy"),
                infos.Horaire,
                infos.NomMedecin,
                qrImage
            );

            return dt;
        }

/*        private async Task SendConfirmationMessageAsync()
        {
            try
            {
                var sender = new SendMessage(); // Cette classe doit utiliser une API réellement fonctionnelle (Twilio, WATI, etc.)

                string patientPhoneNumber = FormatPhoneNumberSenegal(patientInfos.TEL);

                string message =
                    $"Bonjour {patientInfos.NomPrenom},\n\n" +
                    $"Votre rendez-vous avec le Dr {infos.NomMedecin} est confirmé le {infos.DateRv:dd/MM/yyyy} à {infos.Horaire}.\n\n" +
                    $"Votre ticket : {urlPdf}\n\n" +
                    "Merci de votre confiance !";

                var response = await sender.SendTextMessage(patientPhoneNumber, message);

                // Affiche la réponse si possible
                MessageBox.Show("Message envoyé : " + response);
            }
            catch (Exception ex)
            {
                logger.WriteDataError("SendConfirmationMessageAsync", ex.ToString());
                MessageBox.Show($"Erreur lors de l’envoi du message WhatsApp : {ex.Message}", "Erreur WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
*/
/*        private string FormatPhoneNumberSenegal(string rawNumber)
        {
            var digitsOnly = new string(rawNumber.Where(char.IsDigit).ToArray());
            if (digitsOnly.StartsWith("0"))
                digitsOnly = digitsOnly.Substring(1);

            return "+221" + digitsOnly;
        }
*/    }
}
