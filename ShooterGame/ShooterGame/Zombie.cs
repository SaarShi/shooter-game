using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShooterGame
{
    abstract class Zombie : Character
    {

        protected PictureBox zombieImage;
        public string zombieType;
        protected Random rnd;





        public void spawnZombies(Form1 form)
        {
            int zombieType = this.rnd.Next(0, 5);

            if (zombieType == 0)
            {
                // form.nZombie.Spawn(form);
            }
            else
            {
                //  form.nZombie.Spawn(form);
            }

        }
        public void Spawn(Form1 form)
        {
            form.Controls.Add(this.zombieImage);
            form.player.BringToFront();
            this.followPlayer(form);
        }

        public void followPlayer(Form1 form)
        {
            if (this.zombieImage.Left > form.player.Left)
            {
                this.zombieImage.Left -= this.speed;
                if ((string)this.zombieType == "normalZombie")
                    this.zombieImage.Image = Properties.Resources.zleft;
                else
                    this.zombieImage.Image = Properties.Resources.TzombieLeft;
            }
            if (this.zombieImage.Left < form.player.Left)
            {
                this.zombieImage.Left += this.speed;
                if ((string)this.zombieType == "normalZombie")
                    this.zombieImage.Image = Properties.Resources.zright;
                else
                    this.zombieImage.Image = Properties.Resources.TzombieLeft;

            }
            if (this.zombieImage.Top > form.player.Top)
            {
                this.zombieImage.Top -= this.speed;
                if ((string)this.zombieType == "normalZombie")
                    this.zombieImage.Image = Properties.Resources.zup;
                else
                    this.zombieImage.Image = Properties.Resources.TzombieUP;
            }
            if (this.zombieImage.Top < form.player.Top)
            {
                this.zombieImage.Top += this.speed;
                if ((string)this.zombieType == "normalZombie")
                    this.zombieImage.Image = Properties.Resources.zdown;
                else
                    this.zombieImage.Image = Properties.Resources.TzombieDown;
            }

        }

        public void collisionWithPlayer(Form1 form)
        {
            if (this.zombieImage.Bounds.IntersectsWith(form.player.Bounds))
            {
                if (this.zombieImage.Tag != "NULL")
                {
                    form.mainPlayer.getDamage(form, this.damage);
                }
            }


        }

        public void hitZombie(Form1 form)
        {
            if (this.zombieImage.Bounds.IntersectsWith(form.bullet.bullet.Bounds))
            {
                form.mainPlayer.kills++;

                form.Controls.Remove(this.zombieImage);
                (this.zombieImage).Dispose();
                form.Controls.Remove(form.bullet.bullet);
                (form.bullet.bullet).Dispose();
                // form.Controls.Add(zombieList[tZombie.rnd.Next(0, 3)]);
            }

        }

    }
}
