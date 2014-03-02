namespace ShooterRPG.Heroes
{
    using System;
 
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using ShooterRPG.Projectiles;

    public class Archer : Hero
    {
        KeyboardState keyboard;
        KeyboardState prevKeyboard;

        MouseState mouse;
        MouseState prevMouse;

        public string Name { get; set; }


        int Rate = 20;
        int firingTimer = 0;
        float arrowSpeed = 10;
        public static Vector2 currentPlayerPosition;

        public Archer(string name)
            : base(800, 450, 20, 50, 5, 300, new Vector2(40, 40))
        {
            this.Name = name;
            this.SpriteName = "Archer";
            this.SpriteShadow = "Archer_shadow";
            this.Scale = 0.8f;
            this.area = new Rectangle((int)Position.X, (int)Position.Y, 80, 80);
        }

        public float PointDirection(float x, float y, float x2, float y2)
        {
            float diffx = x - x2;
            float diffy = y - y2;
            float adj = diffx;
            float opp = diffy;
            float tan = opp / adj;
            float res = MathHelper.ToDegrees((float)Math.Atan2(opp, adj));
            res = (res - 180) % 360;
            if (res < 0)
                res += 360;
            return res;
        }

        public override void Update()
        {
            if (!this.IsAlive)
            {
                ChaosGame.gameOverMenu = true;
                return;
            }

            this.area.X = (int)this.Position.X;
            this.area.Y = (int)this.Position.Y;

            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            if (keyboard.IsKeyDown(Keys.W) && !this.Collision(this.Position - (new Vector2(0, this.Speed))))
            {
                this.Position -= new Vector2(0, this.Speed);
            }
            if (keyboard.IsKeyDown(Keys.A) && !this.Collision(this.Position - (new Vector2(this.Speed, 0))))
            {
                this.Position -= new Vector2(this.Speed, 0);
            }
            if (keyboard.IsKeyDown(Keys.S) && !this.Collision(this.Position + (new Vector2(0, this.Speed))))
            {
                this.Position += new Vector2(0, this.Speed);
            }
            if (keyboard.IsKeyDown(Keys.D) && !this.Collision(this.Position + (new Vector2(this.Speed, 0))))
            {
                this.Position += new Vector2(this.Speed, 0);
            }
            firingTimer++;
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                this.CheckShooting(this.Rate);
            }
            if (keyboard.IsKeyDown(Keys.C))
            {
                this.CheckShootingSpell(Rate + 20);
            }

            this.rotation = PointDirection(this.Position.X, this.Position.Y, mouse.X, mouse.Y);

            var enemyAttack = EnemyAttack(this.Position);
            if (enemyAttack != null)
            {
                this.Health -= enemyAttack.Damage;
            }

            if (this.Health <=0)
            {
                this.IsAlive = false;
            }

            prevKeyboard = keyboard;
            prevMouse = mouse;
        }

        public void CheckShooting(int rate)
        {
            if (firingTimer > rate)
            {
                firingTimer = 0;
                Shoot();
            }
        }
        public void CheckShootingSpell(int rate)
        {
            if (firingTimer > rate)
            {
                firingTimer = 0;
                ShootSpell();
            }
        }

        private void ShootSpell()
        {
            foreach (var bullet in ListOfDrawableObjects.AllDrawableItems)
            {
                if (bullet.GetType() == typeof(BasicSpell) && !bullet.IsAlive)
                {
                    currentPlayerPosition = this.Position;
                    bullet.Position = this.Position;
                    bullet.rotation = this.rotation;
                    bullet.Speed = arrowSpeed;
                    bullet.IsAlive = true;
                    break;
                }
            }
        }

        public void Shoot()
        {

            foreach (var bullet in ListOfDrawableObjects.AllDrawableItems)
            {
                if (bullet.GetType() == typeof(Arrows) && !bullet.IsAlive)
                {
                    currentPlayerPosition = this.Position;
                    bullet.Position = this.Position;
                    bullet.rotation = this.rotation;
                    bullet.Speed = arrowSpeed;
                    bullet.IsAlive = true;
                    break;
                }
            }
        }
    }
}
