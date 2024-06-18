using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace ShooterGame
{
    [Serializable]
    class Player : Character
    {
        public int ammo, kills;
        public bool up, down, left, right;
        public string facing;
        private PictureBox pic;


        //METHODS
        public Player()
        {
            health = 100;
            ammo = 5;
            kills = 0;
            speed = 10;
            facing = "up";
            isAlive = true;


        }
        public void moveUp(Form1 form)
        {
            this.facing = "up";
            this.up = true;
            form.player.Image = Properties.Resources.playerUp;
        }

        public void moveDown(Form1 form)
        {
            this.facing = "down";
            this.down = true;
            form.player.Image = Properties.Resources.playerDown;
        }

        public void moveLeft(Form1 form)
        {
            this.facing = "left";
            this.left = true;
            form.player.Image = Properties.Resources.playerLeft;
        }

        public void moveRight(Form1 form)
        {
            this.facing = "right";
            this.right = true;
            form.player.Image = Properties.Resources.playerRight;
        }
        public void checkPlayerMovementBoundaries(Form1 form)
        {
            if (left == true && form.player.Left > 0)
            {
                form.player.Left -= speed;
            }
            if (right == true && form.player.Left + form.player.Width < form.ClientSize.Width)
            {
                form.player.Left += speed;
            }
            if (up == true && form.player.Top > 45)
            {
                form.player.Top -= speed;
            }
            if (down == true && form.player.Top + form.player.Height < form.ClientSize.Height)
            {
                form.player.Top += speed;
            }
        }

        public void getDamage(Form1 form, int zombiedamage)
        {
            if (this.health > 1)
            {
                this.health -= zombiedamage;
                if (this.health > 1)
                {
                    form.healthBar.Value = this.health;
                }
            }
            else
            {
                isAlive = false;
                form.gameOver();
            }
        }


    }


}
