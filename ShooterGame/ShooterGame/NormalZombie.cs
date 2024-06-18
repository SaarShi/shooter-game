using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShooterGame
{
    class NormalZombie : Zombie
    {

        public NormalZombie()
        {
            isAlive = true;
            speed = 3;
            health = 100;
            damage = 1;
            zombieType = "normalZombie";
            rnd = new Random();
            zombieImage = new PictureBox();
            zombieImage.Tag = "zombie";
            zombieImage.Image = Properties.Resources.zdown;
            zombieImage.Left = rnd.Next(-200, 600);
            zombieImage.Top = rnd.Next(-200, 600);
            zombieImage.SizeMode = PictureBoxSizeMode.AutoSize;
        }










    }


}



