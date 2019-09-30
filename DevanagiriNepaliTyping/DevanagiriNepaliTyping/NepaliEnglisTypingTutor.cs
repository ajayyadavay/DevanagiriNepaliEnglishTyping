using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevanagiriNepaliTyping
{
    public partial class FrmMain : Form
    {
        FontDialog fontDlg = new FontDialog();
        Dictionary<char, int> ButtonNames = new Dictionary<char, int>();
        public Button[] ButtonArray = new Button[100];

        string GivenText, WrittenText;
        int GivenTextLen, WrittenTextLen, counter;

        string[] DevanagiriProverb = new string[50];
        int TotalDevanagiriProverb, DevanagiriProverbIndex;

        string[] DevanagiriMiddleRow= new string[50];
        int TotalDevanagiriMiddleRow, DevanagiriMiddleRowIndex;

        string[] DevanagiriTopRow = new string[50]; 
        int TotalDevanagiriTopRow, DevanagiriTopRowIndex;

        string[] DevanagiriBottomRow = new string[50];
        int TotalDevanagiriBottomRow, DevanagiriBottomRowIndex;

        string[] DevanagiriName = new string[50];
        int TotalDevanagiriName, DevanagiriNameIndex;

        string[] EnglishName = new string[50];
        int TotalEnglishName, EnglishNameIndex; 

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout fabout = new FrmAbout();
            fabout.Show();
        }

        private void ComboBoxKeyboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxKeyboard.Text == "English")
            {
               // Btna.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                for (int i = 0; i < 35; i++)
                {
                    ButtonArray[i].Font = new Font("Microsoft Sans Serif", 16);
                }
            }
            if (ComboBoxKeyboard.Text == "Devanagiri")
            {
               // Btna.Font = new Font("Preeti", 25, FontStyle.Bold);
                for (int i = 0; i < 35; i++)
                {
                    ButtonArray[i].Font = new Font("Preeti", 25, FontStyle.Bold);
                }
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {

        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            //fontDlg.ShowDialog();

            fontDlg.ShowColor = false;
            fontDlg.ShowApply = false;
            fontDlg.ShowEffects = false;
            fontDlg.ShowHelp = false;

            fontDlg.MaxSize = 36;
            fontDlg.MinSize = 36;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                TxtWrite.Font = fontDlg.Font;
                //TxtWrite.ForeColor = fontDlg.Color;
                //label1.Font = fontDlg.Font;
                //textBox1.BackColor = fontDlg.Color;
                //label1.ForeColor = fontDlg.Color;
            }
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtWrite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WrittenText = TxtWrite.Text;
                WrittenTextLen = WrittenText.Length;

                if (WrittenText[counter - 1] == GivenText[counter - 1])
                {
                    foreach (var item in ButtonNames)
                    {
                        //to make the backcolor of the pressed key to grey
                        if (counter <= GivenTextLen)
                        {
                           if (item.Key == GivenText[counter - 1])
                           {
                                ButtonArray[item.Value].BackColor = Color.FromArgb(64, 64, 64);
                                
                                BtnShiftRight.BackColor = Color.FromArgb(64, 64, 64); // always make shift button of grey color
                                BtnShiftLeft.BackColor = Color.FromArgb(64, 64, 64); // always make shift button of grey color
                           }
                        }
                    }

                    foreach(var item in ButtonNames)
                    {
                        //to identify which key to press next by making its backcolor green
                        if (counter < GivenTextLen)
                        {
                            if (item.Key == GivenText[counter])
                            {
                                ButtonArray[item.Value].BackColor = Color.ForestGreen;

                                if (item.Value >= 35)
                                {
                                    BtnShiftRight.BackColor = Color.ForestGreen; // make shift button of green color when value in dictionary >= 35
                                    BtnShiftLeft.BackColor = Color.ForestGreen; // make shift button of green color when value in dictionary >= 35
                                }
                            }
                        }
                    }

                    if (counter <= GivenTextLen)
                    {
                        counter++;
                    }
                }

                if(WrittenTextLen == GivenTextLen && WrittenText == GivenText)
                {
                    TxtWrite.ForeColor = Color.Lime;

                    //Devanagir --> Proverb
                    if(DevanagiriProverbIndex < TotalDevanagiriProverb - 1)
                    {
                        DevanagiriProverbIndex++;
                    }
                    else
                    {
                        DevanagiriProverbIndex = 0;
                    }

                    if (ComboBoxLanguage.Text == "Devanagiri")
                    {
                        if (ComboBoxCategory.Text == "Proverb")
                        {
                            TxtMainText.Text = DevanagiriProverb[DevanagiriProverbIndex];
                            BtnStart_Click(sender, e);
                        }
                    }

                    //Devanagir --> Middle Row
                    if (DevanagiriMiddleRowIndex < TotalDevanagiriMiddleRow- 1)
                    {
                        DevanagiriMiddleRowIndex++;
                    }
                    else
                    {
                        DevanagiriMiddleRowIndex= 0;
                    }

                    if (ComboBoxLanguage.Text == "Devanagiri" || ComboBoxLanguage.Text == "English")
                    {
                        if (ComboBoxCategory.Text == "Middle Row")
                        {
                            TxtMainText.Text = DevanagiriMiddleRow[DevanagiriMiddleRowIndex];
                            BtnStart_Click(sender, e);
                        }
                    }

                    //Devanagir --> Top Row
                    if (DevanagiriTopRowIndex < TotalDevanagiriTopRow- 1)
                    {
                        DevanagiriTopRowIndex++;
                    }
                    else
                    {
                        DevanagiriTopRowIndex = 0;
                    }

                    if (ComboBoxLanguage.Text == "Devanagiri" || ComboBoxLanguage.Text == "English")
                    {
                        if (ComboBoxCategory.Text == "Top Row")
                        {
                            TxtMainText.Text = DevanagiriTopRow[DevanagiriTopRowIndex];
                            BtnStart_Click(sender, e);
                        }
                    }

                    //Devanagir --> Bottom Row
                    if (DevanagiriBottomRowIndex < TotalDevanagiriBottomRow - 1)
                    {
                        DevanagiriBottomRowIndex++;
                    }
                    else
                    {
                        DevanagiriBottomRowIndex = 0;
                    }

                    if (ComboBoxLanguage.Text == "Devanagiri" || ComboBoxLanguage.Text == "English")
                    {
                        if (ComboBoxCategory.Text == "Bottom Row")
                        {
                            TxtMainText.Text = DevanagiriBottomRow[DevanagiriBottomRowIndex];
                            BtnStart_Click(sender, e);
                        }
                    }

                    //Devanagir --> Name
                    if (DevanagiriNameIndex < TotalDevanagiriName - 1)
                    {
                        DevanagiriNameIndex++;
                    }
                    else
                    {
                        DevanagiriNameIndex = 0;
                    }

                    if (ComboBoxLanguage.Text == "Devanagiri")
                    {
                        if (ComboBoxCategory.Text == "Name")
                        {
                            TxtMainText.Text = DevanagiriName[DevanagiriNameIndex];
                            BtnStart_Click(sender, e);
                        }
                    }

                    //English --> Name
                    if (EnglishNameIndex < TotalEnglishName - 1)
                    {
                        EnglishNameIndex++;
                    }
                    else
                    {
                        EnglishNameIndex = 0;
                    }

                    if (ComboBoxLanguage.Text == "English")
                    {
                        if (ComboBoxCategory.Text == "Name")
                        {
                            TxtMainText.Text = EnglishName[EnglishNameIndex];
                            BtnStart_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxLanguage.Text == "English")
            {
                TxtMainText.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
                TxtWrite.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
            }
            if (ComboBoxLanguage.Text == "Devanagiri")
            {
                TxtMainText.Font = new Font("Preeti", 36, FontStyle.Bold);
                TxtWrite.Font = new Font("Preeti", 36, FontStyle.Bold);
            }

            SelectCategoryAndLanguage();
        }
        public void SelectCategoryAndLanguage()
        {

            //Initialize index of each category
            DevanagiriProverbIndex = 0;
            DevanagiriMiddleRowIndex = 0;
            DevanagiriTopRowIndex = 0;
            DevanagiriBottomRowIndex = 0;
            DevanagiriNameIndex = 0;

            EnglishNameIndex = 0;

            if (ComboBoxLanguage.Text == "Devanagiri")
            {
                //Proverb
                if (ComboBoxCategory.Text == "Proverb")
                {
                    TxtMainText.Text = DevanagiriProverb[DevanagiriProverbIndex];
                }

                //Middle Row
                if (ComboBoxCategory.Text == "Middle Row")
                {
                    TxtMainText.Text = DevanagiriMiddleRow[DevanagiriMiddleRowIndex];
                }

                //Top Row
                if (ComboBoxCategory.Text == "Top Row")
                {
                    TxtMainText.Text = DevanagiriTopRow[DevanagiriTopRowIndex];
                }

                //Bottom Row
                if (ComboBoxCategory.Text == "Bottom Row")
                {
                    TxtMainText.Text = DevanagiriBottomRow[DevanagiriBottomRowIndex];
                }

                //Name
                if (ComboBoxCategory.Text == "Name")
                {
                    TxtMainText.Text = DevanagiriName[DevanagiriNameIndex];
                }
            }

            if (ComboBoxLanguage.Text == "English")
            {
                //Middle Row
                if (ComboBoxCategory.Text == "Middle Row")
                {
                    TxtMainText.Text = DevanagiriMiddleRow[DevanagiriMiddleRowIndex];
                }

                //Top Row
                if (ComboBoxCategory.Text == "Top Row")
                {
                    TxtMainText.Text = DevanagiriTopRow[DevanagiriTopRowIndex];
                }

                //Bottom Row
                if (ComboBoxCategory.Text == "Bottom Row")
                {
                    TxtMainText.Text = DevanagiriBottomRow[DevanagiriBottomRowIndex];
                }

                //Name
                if (ComboBoxCategory.Text == "Name")
                {
                    TxtMainText.Text = EnglishName[EnglishNameIndex];
                }
            }
        }

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCategoryAndLanguage();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //add keyboard in combo box
            ComboBoxKeyboard.Items.Add("English");
            ComboBoxKeyboard.Items.Add("Devanagiri");

            //add language in combo box
            ComboBoxLanguage.Items.Add("English");
            ComboBoxLanguage.Items.Add("Devanagiri");

            //add category in combo box
            ComboBoxCategory.Items.Add("Name");
            //ComboBoxCategory.Items.Add("Proverb");
            ComboBoxCategory.Items.Add("Top Row");
            ComboBoxCategory.Items.Add("Middle Row");
            ComboBoxCategory.Items.Add("Bottom Row");

            //add devanagiri proverb
            TotalDevanagiriProverb = 6;
            DevanagiriProverb[0] = "dg]{ s;}nfO{ /x/ x'b}g .";
            DevanagiriProverb[1] = "t/ gd/]sf] k|x/ x'b}g .";
            DevanagiriProverb[2] = "dflg; gdg]{ s'g} ;x/ x'b}g";
            DevanagiriProverb[3] = "g]kfn hfkfg ;fxf]";
            DevanagiriProverb[4] = "gf k]? bof . oL bof ofqf . gf oLlb lss\\ sfjfnL .";
            DevanagiriProverb[5] = "g]g] lx/f] g\"e] leng .";

            //add devanagiri Middle Row
            TotalDevanagiriMiddleRow = 7;
            DevanagiriMiddleRow[0] = "gd ad dg hs hk kk sh hLjg jg dfs aa dk dd";
            DevanagiriMiddleRow[1] = "a s d j d ss ll kh sdf ll sfh ;gh aa ;; hf";
            DevanagiriMiddleRow[2] = "kkj sf; hgd as ;l df js ha g; ddf ddd fff";
            DevanagiriMiddleRow[3] = "aaa lll slsl fjfj dkdkd ;ds dfj ljf lfj ff";
            DevanagiriMiddleRow[4] = "ldf slf jhd jjhh ssll aaddll jjkksf ;;ljdf";
            DevanagiriMiddleRow[5] = "aldf ljfj jfjf lkdd sfaa lkjf jk lk jf j s";
            DevanagiriMiddleRow[6] = "akl djkl sd sd jj ff sdk dkff llsk sks ksk";

            //add devanagiri Top Row
            TotalDevanagiriTopRow = 9;
            DevanagiriTopRow[0] = "tt yy uu tt yy uu ww oo wwo wowo ru ru ur iiee";
            DevanagiriTopRow[1] = "qqqq wwww ooo eiei ert ert iii erei ieie rty rty";
            DevanagiriTopRow[2] = "pp oo ww rrr ttt uuu iii poi poi qwe qwe ooo eee";
            DevanagiriTopRow[3] = "pqpqp oeoe oooeee irir ieie woi ieow yyy trty trty";
            DevanagiriTopRow[4] = "qpo qpo qpo iiuu wyewye rrr ttt yyy iuo power";
            DevanagiriTopRow[5] = "trey trey piou piou qwerty yree ioew iwww eeee";
            DevanagiriTopRow[6] = "qwwo qooo eee rrr ttt owowo ppwpw owow ieur ruti";
            DevanagiriTopRow[7] = "oepw rururu iiiooo ytr oo rrr rrr trew power";
            DevanagiriTopRow[8] = "iiii oooo pppp trew wyewye rrr uuu iii poi poi";

            //add devanagiri Bottom Row
            TotalDevanagiriBottomRow = 9;
            DevanagiriBottomRow[0] = "zzz mvm xcv xcv mnb mnb zxc Bnb zzzz nnnn cccc bbbb";
            DevanagiriBottomRow[1] = "nnn bbb xxvx vvvv xnznnn cbcbc vxvxvx zbzbzbz zxb";
            DevanagiriBottomRow[2] = "//// vmxxcc cccmmmccmm cbcbc znznz xnxnx cncncm";
            DevanagiriBottomRow[3] = "mmnn ncbc xbn nBv nX// xxnx zzzmz ccvv vvcc cc cxc";
            DevanagiriBottomRow[4] = "zz nn cc m xx nx xxcv xxn //// //// z//z// m//x//";
            DevanagiriBottomRow[5] = "bb bb nn nn zz xx nn bcn xxccv xxnb bn bn xbb bbvc";
            DevanagiriBottomRow[6] = "ccnb bbnn xxbbvv bbnn vvvvn xxccvvbb nnxxnn zzxxnb xx";
            DevanagiriBottomRow[7] = "bb nbv bvn zzz nbx bb m zz // //// xcvb nbc nbc bbvb";
            DevanagiriBottomRow[8] = "NCxn Vb cxv zxb zxb cnc mnc xvvn xxn cnb bvn bvncc vv";

            //add devanagiri Name
            TotalDevanagiriName = 9;
            DevanagiriName[0] = "sn}of af/f ef}F/f g]kfn dx cho ljho lk|tL gu/ ;x/ hxfh syf em/gf ljif";
            DevanagiriName[1] = "syf uug tTsfn ;fxf] afx'anL cfsf/ bz/y ;do cf]d w/gf yfg lhjg d[To\" ut]";
            DevanagiriName[2] = "ljho cfsf/ bdsn qf; cho d'v Ps jg lqd afu efu jf/ sf/ xfxfsf/";
            DevanagiriName[3] = "g]kfn ut] lk|tL k|f]u|fd dfO{s|f] ldgL d]nf gsn ;sn l;len";
            DevanagiriName[4] = "ljif bz/y ;]jf kmn km\"n ;To d]j hot] :ju{ gs{ od/fh g]kfnL";
            DevanagiriName[5] = "af/f w/gf o;n] h;n] ?dfn Joy{ wldnf] cldnf] lk/f] k'Nrf]s";
            DevanagiriName[6] = "gu/ uug Pg e/ ;kgf ljkgf oyf{t ;t{ sn}of pkdxfgu/kflsf";
            DevanagiriName[7] = "ldgL d]nf jf/ sf/ uxg cfsfz CifL j[If pkGof; kfgL lzjfo";
            DevanagiriName[8] = "snf tYo lqz'n bof d]jf ef]hk\"/L SofDk; ;do af/f lbkfjnL";

            //add English Name
            TotalEnglishName = 9;
            EnglishName[0] = "Good bad civil computer Sought Hell Heaven Peace Quick";
            EnglishName[1] = "A quick brown fox jumps over the lazy dog english home";
            EnglishName[2] = "lost in space curse of blood river the great deludge";
            EnglishName[3] = "black temple immortals of meluha shiva triology series";
            EnglishName[4] = "secret of nagas oath of vayuputra lost symbol Da Vinci";
            EnglishName[5] = "Code inferno origin digital fortress temple mount code";
            EnglishName[6] = "extinction files garden hit fix target kalaiya property";
            EnglishName[7] = "asset Avengers Endgame wrath alternate justice flash";
            EnglishName[8] = "lucifer code liability Iron Man stark arrow marvel DC";

            //creating array of Button
            ButtonArray[0] = Btna;
            ButtonArray[1] = Btnb;
            ButtonArray[2] = Btnc;
            ButtonArray[3] = Btnd;
            ButtonArray[4] = Btne;
            ButtonArray[5] = Btnf;
            ButtonArray[6] = Btng;
            ButtonArray[7] = Btnh;
            ButtonArray[8] = Btni;
            ButtonArray[9] = Btnj;
            ButtonArray[10] = Btnk;
            ButtonArray[11] = Btnl;
            ButtonArray[12] = Btnm;
            ButtonArray[13] = Btnn;
            ButtonArray[14] = Btno;
            ButtonArray[15] = Btnp;
            ButtonArray[16] = Btnq;
            ButtonArray[17] = Btnr;
            ButtonArray[18] = Btns;
            ButtonArray[19] = Btnt;
            ButtonArray[20] = Btnu;
            ButtonArray[21] = Btnv;
            ButtonArray[22] = Btnw;
            ButtonArray[23] = Btnx;
            ButtonArray[24] = Btny;
            ButtonArray[25] = Btnz;
            ButtonArray[26] = BtnSpace;
            ButtonArray[27] = BtnBracOpen;
            ButtonArray[28] = BtnBracClose;
            ButtonArray[29] = BtnSemiColon;
            ButtonArray[30] = BtnInvertedComma;
            ButtonArray[31] = BtnBackSlash;
            ButtonArray[32] = BtnComma;
            ButtonArray[33] = BtnFullStop;
            ButtonArray[34] = BtnForeSlash;

            //button when shift is pressed
            ButtonArray[35] = Btna;
            ButtonArray[36] = Btnb;
            ButtonArray[37] = Btnc;
            ButtonArray[38] = Btnd;
            ButtonArray[39] = Btne;
            ButtonArray[40] = Btnf;
            ButtonArray[41] = Btng;
            ButtonArray[42] = Btnh;
            ButtonArray[43] = Btni;
            ButtonArray[44] = Btnj;
            ButtonArray[45] = Btnk;
            ButtonArray[46] = Btnl;
            ButtonArray[47] = Btnm;
            ButtonArray[48] = Btnn;
            ButtonArray[49] = Btno;
            ButtonArray[50] = Btnp;
            ButtonArray[51] = Btnq;
            ButtonArray[52] = Btnr;
            ButtonArray[53] = Btns;
            ButtonArray[54] = Btnt;
            ButtonArray[55] = Btnu;
            ButtonArray[56] = Btnv;
            ButtonArray[57] = Btnw;
            ButtonArray[58] = Btnx;
            ButtonArray[59] = Btny;
            ButtonArray[60] = Btnz;

            ButtonArray[61] = BtnBracOpen;
            ButtonArray[62] = BtnBracClose;
            ButtonArray[63] = BtnSemiColon;
            ButtonArray[64] = BtnInvertedComma;
            ButtonArray[65] = BtnBackSlash;
            ButtonArray[66] = BtnComma;
            ButtonArray[67] = BtnFullStop;
            ButtonArray[68] = BtnForeSlash;

            //Adding {key = key pressed and value = button name} in dictionary
            //charaters without shift key
            ButtonNames.Add('a', 0);
            ButtonNames.Add('b', 1);
            ButtonNames.Add('c', 2);
            ButtonNames.Add('d', 3);
            ButtonNames.Add('e', 4);
            ButtonNames.Add('f', 5);
            ButtonNames.Add('g', 6);
            ButtonNames.Add('h', 7);
            ButtonNames.Add('i', 8);
            ButtonNames.Add('j', 9);
            ButtonNames.Add('k', 10);
            ButtonNames.Add('l', 11);
            ButtonNames.Add('m', 12);
            ButtonNames.Add('n', 13);
            ButtonNames.Add('o', 14);
            ButtonNames.Add('p', 15);
            ButtonNames.Add('q', 16);
            ButtonNames.Add('r', 17);
            ButtonNames.Add('s', 18);
            ButtonNames.Add('t', 19);
            ButtonNames.Add('u', 20);
            ButtonNames.Add('v', 21);
            ButtonNames.Add('w', 22);
            ButtonNames.Add('x', 23);
            ButtonNames.Add('y', 24);
            ButtonNames.Add('z', 25);

            ButtonNames.Add(' ', 26);
            ButtonNames.Add('[', 27);
            ButtonNames.Add(']', 28);
            ButtonNames.Add(';', 29);
            ButtonNames.Add('\'', 30);
            ButtonNames.Add('\\', 31);
            ButtonNames.Add(',', 32);
            ButtonNames.Add('.', 33);
            ButtonNames.Add('/', 34);

            // characters appear when shift is pressed and dictionary value start from 35
            ButtonNames.Add('A', 35);
            ButtonNames.Add('B', 36);
            ButtonNames.Add('C', 37);
            ButtonNames.Add('D', 38);
            ButtonNames.Add('E', 39);
            ButtonNames.Add('F', 40);
            ButtonNames.Add('G', 41);
            ButtonNames.Add('H', 42);
            ButtonNames.Add('I', 43);
            ButtonNames.Add('J', 44);
            ButtonNames.Add('K', 45);
            ButtonNames.Add('L', 46);
            ButtonNames.Add('M', 47);
            ButtonNames.Add('N', 48);
            ButtonNames.Add('O', 49);
            ButtonNames.Add('P', 50);
            ButtonNames.Add('Q', 51);
            ButtonNames.Add('R', 52);
            ButtonNames.Add('S', 53);
            ButtonNames.Add('T', 54);
            ButtonNames.Add('U', 55);
            ButtonNames.Add('V', 56);
            ButtonNames.Add('W', 57);
            ButtonNames.Add('X', 58);
            ButtonNames.Add('Y', 59);
            ButtonNames.Add('Z', 60);

            ButtonNames.Add('{', 61);
            ButtonNames.Add('}', 62);
            ButtonNames.Add(':', 63);
            ButtonNames.Add('\"', 64);
            ButtonNames.Add('|', 65);
            ButtonNames.Add('<', 66);
            ButtonNames.Add('>', 67);
            ButtonNames.Add('?', 68);

        }

        private void TxtWrite_KeyPress(object sender, KeyPressEventArgs e)
        {

            /*if (e.KeyChar == 120)
            {
                Btnx.BackColor = Color.Green;
            }*/
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TxtWrite.Text = "";
            TxtWrite.ForeColor = Color.Yellow;

            counter = 1;

            GivenText = TxtMainText.Text;
            GivenTextLen = GivenText.Length;
            TxtMainTextLen.Text = GivenTextLen.ToString();
            
            for(int i =0; i< 35; i++)
            {
                ButtonArray[i].BackColor = Color.FromArgb(64, 64, 64);
                BtnShiftRight.BackColor = Color.FromArgb(64, 64, 64);
                BtnShiftLeft.BackColor = Color.FromArgb(64, 64, 64);
            }

            foreach (var item in ButtonNames)
            {
                if(item.Key == GivenText[0])
                {
                    ButtonArray[item.Value].BackColor = Color.ForestGreen;

                    if(item.Value >= 35)
                    {
                        BtnShiftRight.BackColor = Color.ForestGreen; // make shift button of green color when value in dictionary >= 35
                        BtnShiftLeft.BackColor = Color.ForestGreen; // make shift button of green color when value in dictionary >= 35
                    }
                }
            }
        }
    }
}
