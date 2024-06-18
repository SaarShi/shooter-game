using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;







namespace ShooterGame
{
    public partial class Form1 : Form
    {
        internal Player mainPlayer;
        internal Bullet bullet;
        internal List<Zombie> nZombie;
        internal TankZombie tZombie;
        internal List<PictureBox> zombieList;
        internal PictureBox gameOverScreen = new PictureBox();




        public Form1()
        {
            InitializeComponent();
            this.KeyUp += Form1_KeyUp;
            mainPlayer = new Player();
            bullet = new Bullet();
            nZombie = new List<Zombie>();
            for(int i=0;i<20;i++)
            {
                if (i % 5 == 0)
                {
                    nZombie.Add(new TankZombie());
                }
                else
                {
                    nZombie.Add(new NormalZombie());
                }
            }

            
            player.Tag = "player";





        }

        private void gameEngine(object sender, EventArgs e)
        {
            mainPlayer.checkPlayerMovementBoundaries(this);

            ammo.Text = "Ammo:" + mainPlayer.ammo;
            kills.Text = "Kills:" + mainPlayer.kills;
            nZombie[0].Spawn(this);
            nZombie[1].Spawn(this);
            //nZombie[0].followPlayer(this);
            nZombie[0].collisionWithPlayer(this);
           // nZombie[1].followPlayer(this);
            nZombie[1].collisionWithPlayer(this);


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammoDrop")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        mainPlayer.ammo += 5;

                    }
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    foreach (Control j in this.Controls)
                    {
                        if (j is PictureBox && (string)j.Tag == "zombie")
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                mainPlayer.kills++;

                                this.Controls.Remove(j);
                                ((PictureBox)j).Dispose();
                                this.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                j.Tag = "NULL";
                                nZombie.RemoveAt(0);
                                nZombie[0].Spawn(this);
                                nZombie[0].Spawn(this);
                                if (mainPlayer.kills % 11 == 0)
                                {
                                    nZombie.Add(new TankZombie());
                                    nZombie.Add(new TankZombie());
                                    nZombie.Add(new TankZombie());
                                    nZombie.Add(new TankZombie());
                                    nZombie[nZombie.Count - 1].Spawn(this);


                                }
                                else
                                {
                                    nZombie.Add(new NormalZombie());
                                    nZombie.Add(new NormalZombie());
                                    nZombie.Add(new NormalZombie());
                                    nZombie.Add(new NormalZombie());

                                }

                                nZombie[0].Spawn(this);
                                nZombie[1].Spawn(this);


                            }
                        }
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(mainPlayer.isAlive)) { return; }

            if (e.KeyCode == Keys.Right) { mainPlayer.moveRight(this); }

            if (e.KeyCode == Keys.Left) { mainPlayer.moveLeft(this); }

            if (e.KeyCode == Keys.Up) { mainPlayer.moveUp(this); }

            if (e.KeyCode == Keys.Down) { mainPlayer.moveDown(this); }
            if (e.KeyCode == Keys.F10)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                gameTimer.Stop();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    saveGame(filePath);
                }
            }
            if (e.KeyCode == Keys.F11)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                gameTimer.Stop();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    loadGame(filePath);
                }
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { mainPlayer.left = false; }

            if (e.KeyCode == Keys.Right) { mainPlayer.right = false; }

            if (e.KeyCode == Keys.Up) { mainPlayer.up = false; }

            if (e.KeyCode == Keys.Down) { mainPlayer.down = false; }

            if (e.KeyCode == Keys.Space && mainPlayer.ammo > 0 && mainPlayer.isAlive == true)
            {
                mainPlayer.ammo--;
                bullet.ShootBullet(mainPlayer, this);
                if (mainPlayer.ammo < 1) { bullet.DropAmmo(this); }
            }
        }


        public void gameOver()
        {
            player.Image = Properties.Resources.dead;
            gameTimer.Stop();
            gameOverScreen.Image = Properties.Resources.gameOverScreen;
            Controls.Add(gameOverScreen);
            gameOverScreen.Left = 0;
            gameOverScreen.Top = 0;
            gameOverScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            gameOverScreen.BringToFront();
            gameOverScreen.Size = new Size(Width, Height);



        }

        

        
        private void loadGame(string filePath)
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Create a FileStream and BinaryFormatter for deserialization
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    // Deserialize the playerKills value from the file
                    int playerKills = (int)binaryFormatter.Deserialize(fileStream);

                    // Update the game state with the loaded data
                    mainPlayer.kills = playerKills;
                    kills.Text = "Kills:" + mainPlayer.kills;
                }
            }
            gameTimer.Start();
        }

        private void saveGame(string filePath)
        {
            int playerKills = mainPlayer.kills;

            // Create a FileStream and BinaryFormatter for serialization
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                // Serialize the playerKills value and save it to the file
                binaryFormatter.Serialize(fileStream, playerKills);
            }


        }

        

        
    } }


