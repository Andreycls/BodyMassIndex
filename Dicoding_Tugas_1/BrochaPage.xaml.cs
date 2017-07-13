using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dicoding_Tugas_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrochaPage : ContentPage
    {
        private static String KURUS     = "Kurus";
        private static String NORMAL    = "Normal";
        private static String GEMUK     = "Kegemukan";
        private static String OBESITAS  = "Obesitas";

        private static char   LAKILAKI  = 'L';
        private static char   PEREMPUAN = 'P';

        public BrochaPage()
        {
            InitializeComponent();

            btnLakiLaki.Clicked += Btn_Clicked;
            btnPerempuan.Clicked += Btn_Clicked;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            String kesimpulan;
            double beratBadanIdeal,nilaiBMI;
            
            var myBtn = (Button)sender;

            nilaiBMI = NilaiBMI(Convert.ToDouble(tinggiBadan.Text), Convert.ToDouble(beratBadan.Text));
            if (myBtn.Text.Equals("Hitung Berat Ideal Laki-Laki"))
            {
                kesimpulan = Kesimpulan(LAKILAKI,nilaiBMI);
                beratBadanIdeal = BeratBadanIdeal(Convert.ToDouble(tinggiBadan.Text),LAKILAKI);
            }
            else
            {
                kesimpulan = Kesimpulan(PEREMPUAN,nilaiBMI);
                beratBadanIdeal = BeratBadanIdeal(Convert.ToDouble(tinggiBadan.Text), PEREMPUAN);
            }
            
            entryKesimpulan.Text = kesimpulan;
            entryBeratBadanIdeal.Text = Convert.ToInt32(beratBadanIdeal).ToString();
            entryNilaiBMI.Text = Convert.ToInt32(nilaiBMI).ToString();
        }

        private String Kesimpulan(char sex, double value)
        {
            if (sex.Equals(LAKILAKI))
            {
                if (value < 17)
                {
                    return KURUS+"( < 17Kg )";
                }
                else if(value >=17 && value <= 23)
                {
                    return NORMAL + "(17 - 23 Kg)";
                }
                else if(value>23 && value <= 27)
                {
                    return GEMUK+"(23 - 27 Kg)";
                }
                else
                {
                    return OBESITAS+"> 27 Kg";
                }
            }
            else
            {
                if (value < 18)
                {
                    return KURUS + "( < 18Kg )";
                }
                else if (value >= 18 && value <= 25)
                {
                    return NORMAL + "(18 - 25 Kg)";
                }
                else if (value > 25 && value <= 27)
                {
                    return GEMUK + "(25 - 27 Kg)";
                }
                else
                {
                    return OBESITAS + "> 27 Kg";
                }
            }
        }
        
        private double NilaiBMI(double tinggiBadan, double beratBadan)
        {
            tinggiBadan = tinggiBadan / 100 ; //satuan meter
            return beratBadan / (tinggiBadan * tinggiBadan);
        }

        private double BeratBadanIdeal(double tinggiBadan,char jenisKelamin)
        {
            double beratBadanIdeal;
            if (jenisKelamin.Equals(LAKILAKI))
            {
                beratBadanIdeal = ( (tinggiBadan-100) - (0.1*(tinggiBadan-100)));
            }
            else
            {
                beratBadanIdeal = ((tinggiBadan - 100) - (0.15 * (tinggiBadan - 100)));
            }

            return beratBadanIdeal;
        }
    }
}
