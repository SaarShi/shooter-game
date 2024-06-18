using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShooterGame
{
    class Bullet
    {
        public string direction;
        public int BulletLeft;
        public int BulletTop;
        public int speed = 20;
        public PictureBox bullet = new PictureBox();
        private Timer BulletTimer = new Timer();
        Random rnd = new Random();


        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }

            if (direction == "right")
            {
                bullet.Left += speed;
            }

            if (direction == "up")
            {
                bullet.Top -= speed;
            }

            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 10 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600)
            {
                BulletTimer.Stop();
                BulletTimer.Dispose();
                bullet.Dispose();
                BulletTimer = null;
                bullet = null;
            }

        }

        public void MakeBullet(Form1 form)
        {

            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = form.player.Left;
            bullet.Top = form.player.Top;
            bullet.BringToFront();

            form.Controls.Add(bullet);


            BulletTimer.Interval = speed;
            BulletTimer.Tick += new EventHandler(BulletTimerEvent);
            BulletTimer.Start();
        }



        public void ShootBullet(Player player, Form1 form)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = player.facing;
            shootBullet.BulletLeft = form.player.Left + (form.Width / 2);
            shootBullet.BulletTop = form.player.Top + (form.Height / 2);
            shootBullet.MakeBullet(form);
        }

        public void DropAmmo(Form1 form)
        {
            PictureBox ammoDrop = new PictureBox();

            ammoDrop.Image = Properties.Resources.ammoDrop;
            ammoDrop.SizeMode = PictureBoxSizeMode.AutoSize;
            ammoDrop.Left = rnd.Next(10, form.ClientSize.Width - ammoDrop.Width);
            ammoDrop.Top = rnd.Next(60, form.ClientSize.Height - ammoDrop.Height);
            ammoDrop.Tag = "ammoDrop";
            form.Controls.Add(ammoDrop);

            ammoDrop.BringToFront();
            form.player.BringToFront();
        }
    }

}
