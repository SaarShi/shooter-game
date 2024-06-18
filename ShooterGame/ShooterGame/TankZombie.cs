using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace ShooterGame
{
    class TankZombie : Zombie
    {



        public TankZombie()
        {
            isAlive = true;
            speed = 1;
            health = 300;
            damage = 5;
            rnd = new Random();
            zombieType = "tankZombie";
            zombieImage = new PictureBox();
            zombieImage.Tag = "zombie";
            zombieImage.Image = Properties.Resources.TzombieDown;
            zombieImage.Left = rnd.Next(-200, 200);
            zombieImage.Top = rnd.Next(-200, 400);

            zombieImage.SizeMode = PictureBoxSizeMode.StretchImage;
            zombieImage.Size = new Size(150, 100);


        }


    }

}


