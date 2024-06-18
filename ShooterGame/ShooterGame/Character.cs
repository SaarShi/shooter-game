using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShooterGame
{
   abstract class Character
    {
     protected int health;
     public bool isAlive;
     protected int speed;
     protected int damage;
      
          

        
        public int getHealth() { return health; }
        public void setHealth(int health) { this.health = health;}
    }
}
