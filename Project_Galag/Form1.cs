using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Project_Galag
{
    class Armo // 갤러그 탄알 클래스
    {
        public int armoX { get; set; } // 갤러그 탄알의 x좌표를 나타내는 프로퍼티
        public int armoY { get; set; } // 갤러그 탄알의 y좌표를 나타내는 프로퍼티
        PictureBox armoObject;
        public Armo(int x, int y, Form fm) // 현재 갤러그의 좌표에 따라 갤러그 탄알의 위치가 설정되고 갤러그 탄알 객체를 생성
        {
            armoX = x + 29;
            armoY = y - 15;
            armoObject = new PictureBox();
            armoObject.Parent = fm;
            armoObject.Image = Image.FromFile("C# 리소스파일\\galagArmo.png");
            armoObject.SizeMode = PictureBoxSizeMode.AutoSize;
            armoObject.Location = new Point(armoX, armoY);
        }
        public void moveArmo() // 현재 갤러그 탄알의 x,y좌표에 따라 갤러그 탄알의 좌표를 업데이트하는 메소드
        {
            armoObject.Location = new Point(armoX, armoY);
        }
        public void setInvisible() // 갤러그 탄알이 화면 상에서 보이지 않게 해주는 메소드
        {
            armoObject.Visible = false;
        }
    }
    class EnemyArmo // 적 탄알 클래스
    {
        public int enemy_armoX { get; set; }// 적 탄알의 x좌표를 나타내는 프로퍼티
        public int enemy_armoY { get; set; }// 적 탄알의 y좌표를 나타내는 프로퍼티
        public int moveX { get; set; } // 보스 공격 패턴 구현을 위한 적 탄알의 x좌표 이동량을 나타내는 프로퍼티
        public int moveY { get; set; } // 보스 공격 패턴 구현을 위한 적 탄알의 y좌표 이동량을 나타내는 프로퍼티
        PictureBox enemyArmoObject;

        /* 적 객체의 적 탄알의 경우 특별한 패턴 없이 앞으로만 움직이기 때문에 moveX,moveY 값이 필요없지만 
         * 보스 객체의 적 탄알의 경우 탄알에 x,y좌표 이동량을 주어 공격 패턴을 구현해낸다. */
        public EnemyArmo(int x, int y, Form fm) // 인자로 받은 x,y값에 따라 적 탄알의 위치가 설정되고 적 탄알 객체를 생성됨
        {
            enemy_armoX = x + 28;
            enemy_armoY = y + 10;
            enemyArmoObject = new PictureBox();
            enemyArmoObject.Parent = fm;
            enemyArmoObject.Image = Image.FromFile("C# 리소스파일\\enemyArmo.png");
            enemyArmoObject.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyArmoObject.Location = new Point(enemy_armoX, enemy_armoY);
        }
        public EnemyArmo(int x, int y, Form fm, int moveX, int moveY) // 인자로 받은 x,y값에 따라 적 탄알의 위치가 설정, 탄알의 x,y좌표 이동량을 설정하고 적 탄알 객체를 생성
        {
            enemy_armoX = x + 28;
            enemy_armoY = y + 10;
            this.moveX = moveX;
            this.moveY = moveY;
            enemyArmoObject = new PictureBox();
            enemyArmoObject.Parent = fm;
            enemyArmoObject.Image = Image.FromFile("C# 리소스파일\\enemyArmo.png");
            enemyArmoObject.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyArmoObject.Location = new Point(enemy_armoX, enemy_armoY);
        }
        public void moveEnemyArmo() // 현재 적 탄알의 x,y좌표에 따라 적 탄알의 좌표를 업데이트하는 메소드
        {
            enemyArmoObject.Location = new Point(enemy_armoX, enemy_armoY);
        }
        public void setInvisible() // 적 탄알이 화면 상에서 보이지 않게 해주는 메소드
        {
            enemyArmoObject.Visible = false;
        }
    }
    class Enemy // 적 객체 클래스
    {
        public int enemyX { get; set; } // 적 객체의 x좌표를 나타내는 프로퍼티
        public int enemyY { get; set; } // 적 객체의 y좌표를 나타내는 프로퍼티
        public int hitCnt = 3; // 적 객체의 체력을 나타내는 변수
        public int flag = 0; // 피격 시 이펙트 처리를 위한 변수
        PictureBox enemyObject;
        public Enemy(int x, int y, Form fm) // 인자로 받은 x,y값에 따라 적 객체의 위치가 설정된다
        {
            enemyX = x;
            enemyY = y;
            enemyObject = new PictureBox();
            enemyObject.Parent = fm;
            enemyObject.Image = Image.FromFile("C# 리소스파일\\enemy.gif");
            enemyObject.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyObject.BackColor = Color.Transparent;
            enemyObject.Location = new Point(enemyX, enemyY);
        }
        public int getWidth() // 적 객체의 너비를 반환하는 메소드
        {
            return enemyObject.Width;
        }
        public void whenEnemyHit() // 적 객체가 갤러그 탄알에 피격 시 이펙트를 발생시켜주는 메소드
        {
            enemyObject.Image = Image.FromFile("C# 리소스파일\\enemyHit.gif");
            flag = 1;
        }
        public void setImage(String str) // 이미지를 새로 설정해주는 메소드
        {
            enemyObject.Image = Image.FromFile(str);
        }
        public void setInvisible() // 적 객체가 화면 상에서 보이지 않게 해주는 메소드
        {
            enemyObject.Visible = false;
        }
    }
    class Boom // 폭탄 아이템 클래스
    {
        public int boomX { get; set; } // 폭탄 객체의 x좌표를 나타내느 프로퍼티
        public int boomY { get; set; } // 폭탄 객체의 y좌표를 나타내느 프로퍼티
        public int LeftOrRight { get; set; } // 폭탄 초기 생성 위치가 좌측면인지 우측면인지 나타내는 프로퍼티
        PictureBox boomObject;
        public Boom(int x, int y, Form fm) // 인자로 받은 x,y값에 따라 폭탄 객체의 위치가 설정된다
        {
            boomX = x;
            boomY = y;
            boomObject = new PictureBox();
            boomObject.Parent = fm;
            boomObject.Image = Image.FromFile("C# 리소스파일\\boom.gif");
            boomObject.SizeMode = PictureBoxSizeMode.AutoSize;
            boomObject.BackColor = Color.Transparent;
            boomObject.Location = new Point(boomX, boomY);
            if (x == 0) // 초기 생성 위치가 좌측면인지 우측면인지에 따라 LeftOrRight 값을 설정한다
                LeftOrRight = 0;
            else
                LeftOrRight = 1;
        }
        public void setLocation() // 현재 폭탄의 x,y좌표값에 따라 폭탄 객체의 위치를 설정해주는 메소드
        {
            boomObject.Location = new Point(boomX, boomY);
        }
        public void setInvisible() // 폭탄 객체가 화면 상에서 보이지 않게 해주는 메소드
        {
            boomObject.Visible = false;
        }
        public int getWidth() // 폭탄 객체의 너비를 반환하는 메소드
        {
            return boomObject.Width;
        }
        public int getHeight() // 폭탄 객체의 높이를 반환하는 메소드
        {
            return boomObject.Height;
        }
    }

    class Heart // 하트 아이템 클래스
    {
        public int heartX { get; set; } // 하트 객체의 x좌표를 나타내느 프로퍼티
        public int heartY { get; set; } // 하트 객체의 y좌표를 나타내느 프로퍼티
        public int LeftOrRight { get; set; } // 하트 초기 생성 위치가 좌측면인지 우측면인지 나타내는 프로퍼티
        PictureBox heartObject;
        public Heart(int x, int y, Form fm) // 인자로 받은 x,y값에 따라 하트 객체의 위치가 설정된다
        {
            heartX = x;
            heartY = y;
            heartObject = new PictureBox();
            heartObject.Parent = fm;
            heartObject.Image = Image.FromFile("C# 리소스파일\\heart.gif");
            heartObject.SizeMode = PictureBoxSizeMode.AutoSize;
            heartObject.BackColor = Color.Transparent;
            heartObject.Location = new Point(heartX, heartY);
            if (x == 0) // 초기 생성 위치가 좌측면인지 우측면인지에 따라 LeftOrRight 값을 설정한다
                LeftOrRight = 0;
            else
                LeftOrRight = 1;
        }
        public void setLocation() // 현재 하트의 x,y좌표값에 따라 하트 객체의 위치를 설정해주는 메소드
        {
            heartObject.Location = new Point(heartX, heartY);
        }
        public void setInvisible() // 하트 객체가 화면 상에서 보이지 않게 해주는 메소드
        {
            heartObject.Visible = false;
        }
        public int getWidth() // 하트 객체의 너비를 반환하는 메소드
        {
            return heartObject.Width;
        }
        public int getHeight() // 하트 객체의 높이를 반환하는 메소드
        {
            return heartObject.Height;
        }
    }
    public partial class Form1 : Form
    {
        private Timer scoreTimer, galagShootingTimer, enemyMakingTimer, boomMakingTimer, heartMakingTimer, enemyShootingTimer, bossShootingTimer;
        Label scoreLabel;
        Label gameOverOrClearLabel;
        Button replay, exit;
        PictureBox galag = new PictureBox();
        PictureBox boomStatus = new PictureBox();
        PictureBox heartStatus = new PictureBox();
        PictureBox bossHP = new PictureBox();
        PictureBox boss = new PictureBox();
        ArrayList galagArmoArray = new ArrayList(); // 모든 갤러그 탄알을 관리하는 리스트
        ArrayList enemyArmoArray = new ArrayList(); // 모든 적 탄알을 관리하는 리스트
        ArrayList enemyArray = new ArrayList(); // 모든 적 객체를 관리하는 리스트
        ArrayList boomArray = new ArrayList(); // 모든 폭탄 객체를 관리하는 리스트
        ArrayList heartArray = new ArrayList(); // 모든 하트 객체를 관리하는 리스트
        int score = 0; // 게임 점수를 나타내는 변수
        int galagX, galagY; // 갤러그의 현재 x,y좌표를 나타내는 변수
        int galagLife = 3; // 갤러그의 체력을 나타내는 변수
        int galagBoom = 0; // 갤러그의 폭탄 갯수를 나타내는 변수
        int galagFlag = 0; // 갤러그의 피격 이펙트 처리를 위한 변수
        int bossAppearTime = 0; // 매 초 증가하다가 설정한 보스 등장 시간에 도달하면 보스 객체가 등장하도록 해주는 변수
        int bossHitCnt = 50; // 보스 객체의 체력을 나타내는 변수
        bool bossAppear = false; // 보스 객체의 출연 여부를 나타내는 변수
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(350, 650);
            this.Text = "Galag";
            this.MaximizeBox = false; // 원활한 게임 플레이를 위한 화면을 고정하기 위해서 윈도우 최대화 버튼을 비활성화
            
            initGalag(); // 갤러그 초기화
            initStatus(); // 상태창 초기화
            initScoreLabel(); // 점수창 초기화

            /* 게임 진행을 위한 타이머들 실행 */         
            startScoreTimer();
            EnableGalagShooting();
            EnableEnemyShooting();
            startMakeEnemy();
            startMakeBoom();
            startMakeHeart();
        }

        void btnExitClick(object sender, EventArgs e) //Exit 선택 시 창을 닫아주는 메소드
        {
            Application.Exit();
        }

        void btnReplayClick(object sender,EventArgs e) // Replay 선택 시 게임을 다시 시작하기 위해 필요한 요소들을 초기화해주는 메소드
        {
            /*  안전한 재시작을 위해 배열 및 화면 요소들을 초기화*/
            galagArmoArray.Clear();
            enemyArmoArray.Clear();
            enemyArray.Clear();
            boomArray.Clear();
            heartArray.Clear();
            Controls.Clear();

            /* 재시작을 위해 필요한 초기 변수값들을 재설정 */
            boss.Visible = true; 
            bossAppear = false;
            galagLife = 3;
            galagBoom = 0;
            score = 0;
            galagFlag = 0;
            bossAppearTime = 0;
            bossHitCnt = 50;
           
            initGalag(); // 갤러그 초기화
            initStatus(); // 상태창 초기화
            initScoreLabel(); // 점수창 초기화

            /* 게임 진행을 위한 타이머들 재실행 */
            startScoreTimer();
            EnableGalagShooting();
            EnableEnemyShooting();
            startMakeEnemy();
            startMakeBoom();
            startMakeHeart();
        }

        void gameOver() // 게임 오버 시 필요한 작업을 수행해주는 메소드
        {
            gameOverOrClearLabel = new Label();
            gameOverOrClearLabel.Text = "GAME OVER";
            gameOverOrClearLabel.ForeColor = Color.Red;
            gameOverOrClearLabel.Font = new Font("맑은 고딕", 25);
            gameOverOrClearLabel.Location = new Point(ClientSize.Width/2-105, ClientSize.Height/2-110);
            gameOverOrClearLabel.AutoSize = true;
            Controls.Add(gameOverOrClearLabel); // GAME OVER 라벨을 화면에 보여준다
            initScoreLabel();
            //gameOver() 메소드를 호출하기 전에 화면 상의 모든 요소들을 제거했기 때문에 게임 오버 시점에 score를 다시 확인할 수 있도록 화면에 추가해준다

            /* Replay를 수행할 수 있는 버튼을 화면 상에 추가한다 */
            replay = new Button();
            replay.Text = "REPLAY";
            replay.ForeColor = Color.White;
            replay.Font = new Font("맑은 고딕", 15);
            replay.Location = new Point(ClientSize.Width / 2 - 95, ClientSize.Height / 2-30);
            replay.AutoSize = true;
            replay.Click += new EventHandler(btnReplayClick);//Replay 버튼 클릭 시 이벤트 등록
            Controls.Add(replay);// Replay 버튼 추가

            /*  exit를 수행할 수 있는 버튼을 화면 상에 추가한다 */
            exit = new Button();
            exit.Text = "  EXIT  ";
            exit.ForeColor = Color.White;
            exit.Font = new Font("맑은 고딕", 15);
            exit.Location = new Point(ClientSize.Width / 2 + 5, ClientSize.Height / 2 - 30);
            exit.AutoSize = true;
            exit.Click += new EventHandler(btnExitClick);// exit 버튼 클릭 시 이벤트 등록
            Controls.Add(exit);// exit 버튼 추가    
        }

        void gameClear() // 게임 클리어 시 필요한 작업을 수행해주는 메소드
        {
            gameOverOrClearLabel = new Label();
            gameOverOrClearLabel.Text = "GAME CLEAR!";
            gameOverOrClearLabel.ForeColor = Color.Yellow;
            gameOverOrClearLabel.Font = new Font("맑은 고딕", 25);
            gameOverOrClearLabel.Location = new Point(ClientSize.Width / 2 - 115, ClientSize.Height / 2 - 110);
            gameOverOrClearLabel.AutoSize = true;
            Controls.Add(gameOverOrClearLabel); // GAME CLEAR 를 했음을 보여주는 라벨을 화면에 보여준다
            initScoreLabel(); 
            // gameClear() 메소드를 호출하기 전에 화면 상의 모든 요소들을 제거했기 때문에 게임 클리어 시점에 score를 다시 확인할 수 있도록 화면에 추가해준다

            /* Replay를 수행할 수 있는 버튼을 화면 상에 추가한다 */
            replay = new Button();
            replay.Text = "REPLAY";
            replay.ForeColor = Color.White;
            replay.Font = new Font("맑은 고딕", 15);
            replay.Location = new Point(ClientSize.Width / 2 - 95, ClientSize.Height / 2 - 30);
            replay.AutoSize = true;
            replay.Click += new EventHandler(btnReplayClick); //Replay 버튼 클릭 시 이벤트 등록
            Controls.Add(replay); // Replay 버튼 추가

            /*  exit를 수행할 수 있는 버튼을 화면 상에 추가한다 */
            exit = new Button();
            exit.Text = "  EXIT  ";
            exit.ForeColor = Color.White;
            exit.Font = new Font("맑은 고딕", 15);
            exit.Location = new Point(ClientSize.Width / 2 + 5, ClientSize.Height / 2 - 30);
            exit.AutoSize = true;
            exit.Click += new EventHandler(btnExitClick); // exit 버튼 클릭 시 이벤트 등록
            Controls.Add(exit); // exit 버튼 추가
        }

        void initGalag() // 갤러그 객체를 초기화해주는 메소드
        {
            galag.Parent = this;
            galag.Image = Image.FromFile("C# 리소스파일\\galag.gif");
            galag.SizeMode = PictureBoxSizeMode.AutoSize;
            galagX = 145;
            galagY = 520;
            galag.Location = new Point(galagX, galagY);        
        }

        void initStatus() // 갤러그의 체력, 폭탄의 상태창을 초기화해주는 메소드
        {
            heartStatus.Parent = this;
            heartStatus.Image = Image.FromFile("C# 리소스파일\\HeartBar" + galagLife.ToString() + ".png");
            heartStatus.SizeMode = PictureBoxSizeMode.AutoSize;
            heartStatus.Location = new Point(5, ClientSize.Height - 70);

            boomStatus.Parent = this;
            boomStatus.Image = Image.FromFile("C# 리소스파일\\boombar" + galagBoom.ToString() + ".png");
            boomStatus.SizeMode = PictureBoxSizeMode.AutoSize;
            boomStatus.Location = new Point(105, ClientSize.Height - 53);
        }

        void initScoreLabel() // score를 표시하기 위한 라벨 초기화 메소드
        {
            scoreLabel = new Label();
            scoreLabel.Text = "SCORE: " + score.ToString();
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Location = new Point(ClientSize.Width - 140, ClientSize.Height - 40);
            scoreLabel.AutoSize = true;
            Controls.Add(scoreLabel);
        }

        void startScoreTimer() // 스코어를 측정해주고 보스 등장을 수행해주는 타이머
        {
            scoreTimer = new Timer();
            scoreTimer.Tick += Timer_Tick1;
            scoreTimer.Interval = 1000;
            scoreTimer.Start();
        }

        void EnableGalagShooting() // 생성된 갤러그의 탄알에 대한 이동과 적 객체 및 보스 객체에 대한 피격 판정을 수행해주는 타이머
        {
            galagShootingTimer = new Timer();
            galagShootingTimer.Tick += Timer_Tick2;
            galagShootingTimer.Interval = 200;
            galagShootingTimer.Start();

        }
        void startMakeEnemy() // 적 객체 생성을 수행해주는 타이머
        {
            enemyMakingTimer = new Timer();
            enemyMakingTimer.Tick += Timer_Tick3;
            enemyMakingTimer.Interval = 1000;
            enemyMakingTimer.Start();
        }

        void startMakeBoom() // 폭탄 생성 및 획득을 수행해주는 타이머
        {
            boomMakingTimer = new Timer();
            boomMakingTimer.Tick += Timer_Tick4;
            boomMakingTimer.Interval = 100;
            boomMakingTimer.Start();
        }
        void startMakeHeart() // 하트 생성 및 획득을 수행해주는 타이머
        {
            heartMakingTimer = new Timer();
            heartMakingTimer.Tick += Timer_Tick5;
            heartMakingTimer.Interval = 100;
            heartMakingTimer.Start();
        }
        void EnableEnemyShooting() // 적 객체의 공격 패턴 생성 및 갤러그 피격 판정을 수행해주는 타이머
        {
            enemyShootingTimer = new Timer();
            enemyShootingTimer.Tick += Timer_Tick6;
            enemyShootingTimer.Interval = 200;
            enemyShootingTimer.Start();

        }
        void EnableBossShooting() // 보스 객체의 공격 패턴을 생성 및 갤러그 피격 판정을 수행해주는 타이머
        {
            bossShootingTimer = new Timer();
            bossShootingTimer.Tick += Timer_Tick7;
            bossShootingTimer.Interval = 200;
            bossShootingTimer.Start();
        }
        void useBoom() // 폭탄 사용 시 필요한 작업을 수행하는 메소드
        {
            galagBoom--; // 폭탄을 사용했으므로 폭탄 갯수 1개 감소
            boomStatus.Image = Image.FromFile("C# 리소스파일\\boombar" + galagBoom.ToString() + ".png"); // 현재 폭탄 갯수에 맞게 폭탄 소지 상태 업데이트

            /* 폭탄 사용 시 적 객체를 전부 즉시 처치한다. 따라서 폭탄 사용 시 화면 상에 있는 모든 적 객체를 삭제한다 */
            if (bossAppear == false)
            {
                for (int i = 0; i < enemyArray.Count; i++)
                {
                    Enemy tmp = enemyArray[i] as Enemy;
                    tmp.setInvisible();
                }
                enemyArray.Clear();
            }
            else // 보스 객체가 등장해 있는 경우 적 객체 즉시 처치 대신에 보스 객체에게 5 데미지를 준다.
                bossHitCnt -= 5;

            /* 폭탄 사용 시 적 객체 및 보스 객체의 화면 상의 탄알을 전부 삭제한다 */
            for(int i = 0; i < enemyArmoArray.Count; i++)
            {
                EnemyArmo tmp = enemyArmoArray[i] as EnemyArmo;
                tmp.setInvisible();
            }
            enemyArmoArray.Clear();

            if (bossHitCnt <= 0) // 보스 객체의 체력이 전부 소모되면
            {
                boss.Visible = false; // 보스 객체를 화면에서 제거하고
                bossAppear = false; // 보스 객체의 등장 상태를 false로 설정
                score += 1000; // score는 1000점을 추가한다

                /* 게임을 클리어하였기 때문에 실행하던 모든 타이머들을 중단시키고 화면 상에 남아있던 모든 요소들을 제거한다 */
                boomMakingTimer.Stop();
                enemyShootingTimer.Stop();
                galagShootingTimer.Stop();
                enemyMakingTimer.Stop();
                heartMakingTimer.Stop();
                scoreTimer.Stop();
                bossShootingTimer.Stop();
                this.Controls.Clear();
                gameClear(); // 게임 클리어 시 화면을 구성한다
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // 키보드 입력에 따른 이벤트를 정의하는 메소드. 갤러그를 조작하고 폭탄 아이템을 사용할 수 있도록 한다
        {
            switch (e.KeyCode)
            {
                case Keys.Up: // 위 방향키 입력 시 누르면 위로 이동
                    galagY -= 7;
                    if (galagY < 30) // 위 방향에 대해서 일정 구간 아래는 갤러그가 넘어가지 못하도록 한다
                        galagY = 30;
                    galag.Location = new Point(galagX, galagY);
                    break;
                case Keys.Down: // 아래 방향키 입력 시 아래로 이동
                    galagY += 7;
                    if (galagY > ClientSize.Height - 120) // 아래 방향에 대해서 일정 구간 이상은 갤러그가 넘어가지 못하도록 한다
                        galagY = ClientSize.Height - 120;
                    galag.Location = new Point(galagX, galagY);
                    break;
                case Keys.Right: // 오른쪽 방향키 입력 시 오른쪽으로 이동
                    galagX += 7;
                    if (galagX > ClientSize.Width - 70) // 오른쪽 방향에 대해서 일정 구간 이상은 갤러그가 넘어가지 못하도록 한다.
                        galagX = ClientSize.Width - 70;
                    galag.Location = new Point(galagX, galagY);
                    break;
                case Keys.Left: // 왼족 방향키 입력 시 왼쪽으로 이동
                    galagX -= 7;
                    if (galagX < 0) // 왼쪽 방향에 대해서 일정 구간 아래는 갤러그가 넘어가지 못하도록 한다
                        galagX = 0;
                    galag.Location = new Point(galagX, galagY);
                    break;
                case Keys.Space: // space 바 입력 시 갤러그가 탄알을 발사하도록 한다
                    galagArmoArray.Add(new Armo(galagX-9, galagY, this));          
                    break;
                case Keys.F when galagBoom > 0: // f 키 입력 시 갤러그가 폭탄을 사용할 수 있도록 한다. 폭탄을 소지하고 있을 때만 폭탄을 사용할 수 있다
                    useBoom(); // 폭탄 사용 시 필요한 작업을 수행하는 메소드
                    break;
            }
        }

        private void Timer_Tick7(object sender, EventArgs e) // 보스 객체의 공격패턴을 구현하고 갤러그가 보스 객체의 탄알에 피격 시 발생하는 작업을 수행하는 타이머7
        {
            if (galagFlag == 1)// 현재 갤러그 객체가 피격 상태라면, 즉 피격 당한 이펙트를 보여주었다면
            {
                galag.Image = Image.FromFile("C# 리소스파일\\galag.gif");// 다시 기존 상태의 이미지로 설정
                galagFlag = 0;// 기존 상태로 다시 설정
            }

            Random rand = new Random();
            int bossArmoAppear= rand.Next(0, 1000); // 랜덤변수를 통해 보스 객체의 공격 확률을 설정
            if (bossArmoAppear < 120) // 보스 객체가 공격을 수행하는 경우
            {
                Random pattern = new Random();
                int bossPattern = rand.Next(0, 100); // 랜덤변수를 통해 보스 객체의 공격 패턴을 선택하여 공격을 수행한다.
                if (bossPattern < 25) // 25% 확률로는 방사형으로 움직이는 탄알을 발사하는 패턴
                {
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, -10, 17));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, -5, 17));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 0, 17));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 5, 17));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 10, 17));
                }
                else if (bossPattern < 60) // 35% 확률로는 우측에서 생성되고 직진하며 움직이는 탄알을 발사하는 패턴
                {
                    enemyArmoArray.Add(new EnemyArmo(240, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(180, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(120, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(60, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(0, 200, this, 0, 15));
                }
                else if(bossPattern<85) // 35% 확률로는 좌측에서 생성되고 직진하며 움직이는 탄알을 발사하는 패턴
                {
                    enemyArmoArray.Add(new EnemyArmo(60, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(120, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(180, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(240, 200, this, 0, 15));
                    enemyArmoArray.Add(new EnemyArmo(300, 200, this, 0, 15));
                }
                else // 15% 확률로는 더 빠르게 방사형으로 움직이는 탄알을 발사하는 패턴
                {
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, -15, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, -10, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, -5, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 0, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 5, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 10, 20));
                    enemyArmoArray.Add(new EnemyArmo(150, 200, this, 15, 20));
                }             
            }

            for (int i = 0; i < enemyArmoArray.Count; i++) // 보스 객체의 탄알을 확인해 갤러그가 적 객체의 탄알에 피격되었는지 안되었는지를 판단하는 반복문
            {             
                EnemyArmo tmp = enemyArmoArray[i] as EnemyArmo;
                tmp.enemy_armoY += tmp.moveY;
                tmp.enemy_armoX += tmp.moveX;
                // 보스의 공격 패턴별로 탄알의 x,y방향의 이동량을 생성자를 통해서 정의해두었기 때문에 이를 사용해서 보스 객체의 탄알의 좌표값을 결정

                if (tmp.enemy_armoY > ClientSize.Height-70) // 보스 객체의 탄알이 화면 아래 부분 일정 구간을 넘어가면 삭제하도록 한다
                {
                    tmp.setInvisible();
                    enemyArmoArray.RemoveAt(i);
                }
                else
                {
                    // 갤러그의 히트박스에 보스 객체의 탄알이 만나면 갤러그가 피격된 것으로 판단
                    if ((tmp.enemy_armoX >= (galagX - galag.Width / 2) + 30 && tmp.enemy_armoX <= (galagX + galag.Width / 2) + 22) && (tmp.enemy_armoY > galagY - galag.Height / 2) && (tmp.enemy_armoY < galagY + galag.Height / 2)) //y값도 조정 필요 이미 지나간 armo도 맞게 됨
                    {
                        tmp.setInvisible();
                        enemyArmoArray.RemoveAt(i); // 갤러그와 피격된 보스 객체의 탄알은 삭제
                        galag.Image = Image.FromFile("C# 리소스파일\\galagHit.gif"); // 갤러그 피격 시 이펙트 발생
                        galagFlag = 1; // 현재 피격당한 이펙트를 보여주었음을 알려줌
                        galagLife--;
                        if (galagLife == -1)// 모든 하트가 소모된 경우 게임오버에 대해서 처리한다
                        {
                            /* 게임 오버되었기 때문에 실행하던 모든 타이머들을 중단시키고 화면 상에 남아있던 모든 요소들을 제거한다 */
                            boomMakingTimer.Stop();
                            enemyShootingTimer.Stop();
                            galagShootingTimer.Stop();
                            enemyMakingTimer.Stop();
                            heartMakingTimer.Stop();
                            scoreTimer.Stop();
                            bossShootingTimer.Stop(); //현재 보스가 나와있는 상황이므로 보스가 없을 때와 달리 보스의 공격패턴을 구현해주는 타이머7도 추가적으로 중단한다
                            this.Controls.Clear();
                            gameOver(); // 게임 오버 시 화면을 구성한다
                        }
                        else if (galagLife >= 0) //갤러그 체력이 남아있는 경우 피격 시 하트가 1개씩 감소
                            heartStatus.Image = Image.FromFile("C# 리소스파일\\HeartBar" + galagLife.ToString() + ".png"); // 피격 시 감소한 하트 수에 따라 현재 하트 상태 업데이트
                    }
                }
                tmp.moveEnemyArmo(); // 실질적 보스 객체의 탄알 이동
            }
        }

        private void Timer_Tick6(object sender, EventArgs e) // 갤러그가 적 객체의 탄알에 피격 시 발생하는 작업을 수행하는 타이머6
        {
            if (galagFlag == 1) // 현재 갤러그 객체가 피격 상태라면, 즉 피격 당한 이펙트를 보여주었다면
            {
                galag.Image = Image.FromFile("C# 리소스파일\\galag.gif"); // 다시 기존 상태의 이미지로 설정
                galagFlag = 0; // 기존 상태로 다시 설정
            }
            Random rand = new Random();
            int enemy_idx;
            if (enemyArray.Count != 0) // 적 객체가 존재하는 경우
            {
                int enemyArmo_appear = rand.Next(0, 1000); // 일정 확률로 적 탄알을 생성한다
                if (enemyArmo_appear < 300) // 적 탄알을 생성되는 경우
                {
                    enemy_idx = rand.Next(0, enemyArray.Count); // 현재 존재하는 적 객체들 중에서 선택하여
                    Enemy enemy = enemyArray[enemy_idx] as Enemy;
                    int enemyX = enemy.enemyX;
                    int enemyY = enemy.enemyY;
                    enemyArmoArray.Add(new EnemyArmo(enemyX, enemyY, this)); // 선택된 적 객체가 적 탄알을 발사하도록 한다.
                }
            }

            for (int i = 0; i < enemyArmoArray.Count; i++) // 모든 적 객체의 탄알을 확인해 갤러그가 적 객체의 탄알에 피격되었는지 안되었는지를 판단하는 반복문
            {
                int armo_speed;
                EnemyArmo tmp = enemyArmoArray[i] as EnemyArmo;
          
                armo_speed = rand.Next(5, 20); 
                tmp.enemy_armoY += armo_speed; // 적 객체의 탄알의 이동을 위한 좌표값 설정. 이동속도는 일정 속도 랜덤값을 이용하여 랜덤한 속도를 갖는다
                
                if (tmp.enemy_armoY > ClientSize.Height-70) // 적 객체의 탄알이 화면 아래 부분 일정 구간을 넘어가면 삭제하도록 한다
                {
                    tmp.setInvisible();
                    enemyArmoArray.RemoveAt(i);
                }
                else
                {
                    // 갤러그의 히트박스에 적 객체의 탄알이 만나면 갤러그가 피격된 것으로 판단
                    if ((tmp.enemy_armoX >= (galagX - galag.Width / 2) + 30 && tmp.enemy_armoX <= (galagX + galag.Width / 2) + 22) && (tmp.enemy_armoY > galagY - galag.Height / 2) && (tmp.enemy_armoY < galagY + galag.Height / 2)) //y값도 조정 필요 이미 지나간 armo도 맞게 됨
                    {
                        tmp.setInvisible();
                        enemyArmoArray.RemoveAt(i); // 갤러그와 피격된 적 객체의 탄알은 삭제
                        galag.Image = Image.FromFile("C# 리소스파일\\galagHit.gif"); // 갤러그의 피격 시 이펙트 발생
                        galagFlag = 1; // 현재 피격당한 이펙트를 보여주었음을 알려줌

                        galagLife--;
                        if (galagLife == -1) // 모든 하트가 소모된 경우 게임오버에 대해서 처리한다
                        {
                            /* 게임 오버되었기 때문에 실행하던 모든 타이머들을 중단시키고 화면 상에 남아있던 모든 요소들을 제거한다 */
                            boomMakingTimer.Stop();
                            enemyShootingTimer.Stop();
                            galagShootingTimer.Stop();
                            enemyMakingTimer.Stop();
                            heartMakingTimer.Stop();
                            scoreTimer.Stop();
                            this.Controls.Clear();
                            gameOver(); //게임 오버 시 화면을 구성한다
                        }
                        else if (galagLife >= 0) //갤러그 체력이 남아있는 경우 피격 시 하트가 1개씩 감소
                            heartStatus.Image = Image.FromFile("C# 리소스파일\\HeartBar" + galagLife.ToString() + ".png"); // 피격 시 감소한 하트 수에 따라 현재 하트 상태 업데이트
                    }                   
                }
                tmp.moveEnemyArmo(); // 실질적 적 객체의 탄알 이동을 수행
            }
        }
        private void Timer_Tick5(object sender, EventArgs e) // 하트 객체를 생성하는 타이머5
        {
            Random heartAppear = new Random();
            int n = heartAppear.Next(0, 10000); // 랜덤 변수를 통해 일정확률로 하트를 생성
            if (n < 100) // 하트 생성 시
            {
                //새로운 하트 생성을 위한 x,y좌표 설정
                Random heartX = new Random();
                Random heartY = new Random();
                int x = heartX.Next(0, 2);
                int y = heartY.Next(0, 450);
                // 하트가 좌, 우 측면 둘 중 한쪽에서 생성되서 이동하기 때문에 랜덤변수 값에 따라서 x좌표가 맨좌측인지, 맨우측인지가 결정된다
                if (x == 0)
                    x = 0;
                else
                    x = ClientSize.Width;

                if (heartArray.Count < 2) // 화면에 표시되는 하트의 개수를 2개로 제한하여 하트를 생성한다
                    heartArray.Add(new Heart(x, y, this));
            }

            if (heartArray.Count != 0) // 생성된 하트가 있는 경우
            {
                for (int i = 0; i < heartArray.Count; i++) // 생성된 하트를 갤러그가 획득했는지를 판단하는 반복문
                {
                    Heart tmp = heartArray[i] as Heart;
                    if (tmp.LeftOrRight == 0)
                        tmp.heartX += 7;// 생성된 하트의 시작 x의 위치가 좌측면인 경우, 오른쪽으로 하트의 이동을 위한 x좌표값을 설정
                    else
                        tmp.heartX -= 7;// 생성된 하트의 시작 x의 위치가 우측면인 경우, 왼쪽으로 하트의 이동을 위한 x좌표값을 설정
                    tmp.heartY += 7;// 하트의 이동을 위한 y좌표값을 설정
                    tmp.setLocation();// 실제 하트의 이동을 위한 좌표값 설정

                    if (tmp.heartY > ClientSize.Height - 100)// 하트가 일정 범위 아래로 내려가는 경우 하트가 사라지게 한다
                    {
                        tmp.setInvisible();
                        heartArray.RemoveAt(i);
                    }
                    // 하트의 히트박스와 갤러그가 겹치게 되면 하트를 먹은 것으로 판단한다
                    else if (tmp.heartX - tmp.getWidth() / 2 <= galagX && galagX <= tmp.heartX + tmp.getWidth() / 2 && tmp.heartY - tmp.getHeight()/2 <= galagY && galagY <= tmp.heartY + tmp.getHeight() / 2)
                    {
                        if (0<=galagLife && galagLife < 3)// 하트 획득 시 갤러그의 하트 카운트를 증가시킨다. 하트는 최대 3번까지만 획득할 수 있도록 한다
                            galagLife++;
                        heartStatus.Image = Image.FromFile("C# 리소스파일\\heartbar" + galagLife.ToString() + ".png");// 획득한 하트의 갯수에 따라 하트 획득 상태 표시를 업데이트
                        tmp.setInvisible();
                        heartArray.RemoveAt(i);// 갤러그와 닿은 하트는 획득된 것이므로 화면에서 삭제한다
                    }
                }
            }
        }
        private void Timer_Tick4(object sender, EventArgs e) // 폭탄 객체를 생성하는 타이머4
        {
            Random boomAppear = new Random();
            int n = boomAppear.Next(0, 10000); // 랜덤변수를  통해서 일정 확률로 폭탄을 생성
            if (n < 100) // 폭탄 생성 시
            {
                //새로운 폭탄 생성을 위한 x,y 좌표를 설정
                Random boomX = new Random();
                Random boomY = new Random();
                int x = boomX.Next(0, 2);
                int y = boomY.Next(0, 450);

                // 폭탄이 좌, 우 측면 둘 중 한쪽에서 생성되서 이동하기 때문에 랜덤변수 값에 따라서 x좌표가 맨좌측인지, 맨우측인지가 결정된다
                if (x == 0)
                    x = 0;
                else
                    x = ClientSize.Width;

                if (boomArray.Count < 2) // 화면에 표시되는 폭탄의 개수를 2개로 제한하여 폭탄을 생성한다
                    boomArray.Add(new Boom(x, y, this));
            }

            if (boomArray.Count != 0) // 생성된 폭탄이 있는 경우
            {
                for (int i = 0; i < boomArray.Count; i++) // 생성된 폭탄을 갤러그가 획득했는지를 판단하는 반복문
                {
                    Boom tmp = boomArray[i] as Boom;
                    if (tmp.LeftOrRight == 0)
                        tmp.boomX += 7;// 생성된 폭탄의 시작 x의 위치가 좌측면인 경우, 오른쪽으로 폭탄의 이동을 위한 x좌표값을 설정
                    else
                        tmp.boomX -= 7;// 생성된 폭탄의 시작 x의 위치가 우측면인 경우, 왼쪽으로 폭탄의 이동을 위한 x좌표값을 설정
                    tmp.boomY += 7; // 폭탄의 이동을 위한 y좌표값을 설정
                    tmp.setLocation(); // 실제 폭탄의 이동을 위한 좌표값 설정

                    if (tmp.boomY > ClientSize.Height - 100) // 폭탄이 일정 범위 아래로 내려가는 경우 폭탄이 사라지게 한다
                    {
                        tmp.setInvisible();
                        boomArray.RemoveAt(i);
                    }

                    // 폭탄의 히트박스와 갤러그가 겹치게 되면 폭탄을 먹은 것으로 판단한다
                    else if (tmp.boomX - tmp.getWidth() / 2 <= galagX && galagX <= tmp.boomX + tmp.getWidth() / 2 && tmp.boomY - tmp.getHeight() / 2 <= galagY && galagY <= tmp.boomY + tmp.getHeight() / 2)
                    {
                        if (galagBoom < 3) // 폭탄 획득 시 갤러그의 폭탄 카운트를 증가시킨다. 폭탄은 최대 3번까지만 획득할 수 있도록 한다
                            galagBoom++;
                        boomStatus.Image = Image.FromFile("C# 리소스파일\\boombar" + galagBoom.ToString() + ".png"); // 획득한 폭탄의 갯수에 따라 폭탄 획득 상태 표시를 업데이트
                        tmp.setInvisible();
                        boomArray.RemoveAt(i); // 갤러그와 닿은 폭탄은 획득된 것이므로 화면에서 삭제한다
                    }
                }
            }
        }

        private void Timer_Tick3(object sender, EventArgs e) // 적 객체를 생성하는 타이머3
        {
            Random enemyAppear = new Random(); 
            int n = enemyAppear.Next(0, 100); // 랜덤변수를 통해서 일정 확률로 적 객체 생성을 수행한다

            if (n < 100) // 적 객체 생성 시
            {
                // 새로운 적 객체 생성을 위한 랜덤한 x,y 좌표를 얻는다
                Random enemyX = new Random();
                Random enemyY = new Random();
                int x = enemyX.Next(10, ClientSize.Width - 50);
                int y = enemyY.Next(0, 200);

                if (enemyArray.Count == 0) // 현재 적 객체가 하나도 없다면 얻은 x,y 좌표를 가진 적 객체를 바로 생성한다
                    enemyArray.Add(new Enemy(x, y, this));

                else if (enemyArray.Count < 6) // 현재 적 객체가 이미 있는 경우
                {
                    // 이미 생성되어 있는 적 객체들을 확인하여 새로 생성하는 적 객체가 기존 적 객체들과 x축으로 겹치지 않는 경우만 새로운 적 객체를 생성하도록 한다
                    foreach (Enemy tmp in enemyArray)
                    {
                        int x1 = tmp.enemyX - tmp.getWidth() / 2;
                        int x2 = tmp.enemyX + tmp.getWidth() / 2;
                        if (((x - tmp.getWidth() / 2) >= x1 && (x - tmp.getWidth() / 2) <= x2) || ((x + tmp.getWidth() / 2) >= x1 && (x + tmp.getWidth() / 2) <= x2))
                            return; // 기존 적 객체의 x좌표와 새로운 적 객체의 x좌표가 겹치는 경우 새로운 적 객체를 생성하지 않고 return
                    }
                    enemyArray.Add(new Enemy(x, y, this)); // 기존 적 객체의 x좌표와 새로운 적 객체의 x좌표가 겹치지 않는 경우 새로운 적 객체를 생성
                }
            }
        }
        private void Timer_Tick2(object sender, EventArgs e) // 적 객체 및 보스 객체가 갤러그의 탄알에 피격 시 발생하는 작업을 수행하는 타이머2
        {
            foreach (Enemy enemy in enemyArray) // 적 객체가 갤러그 탄알에 피격당했을 때 피격당한 이펙트를 보여주고 기존 상태로 돌아오기 위한 반복문
            {
                if (enemy.flag == 1) // 현재 적 객체가 피격 상태라면, 즉 피격 당한 이펙트를 보여주었다면
                {
                    enemy.setImage("C# 리소스파일\\enemy.gif"); // 다시 기존 상태 이미지로 설정
                    enemy.flag = 0; // 기존 상태로 다시 설정
                }
            }

            for (int i = 0; i < galagArmoArray.Count; i++) //현재 존재하는 갤러그 탄알들을 움직이게 하며 적 객체를 피격하였는지를 확인하는 반복문
            {
                Armo tmp = galagArmoArray[i] as Armo;
                tmp.armoY -= 15; // 갤러그 탄알의 이동을 위한 좌표값 설정
                if (tmp.armoY < -10) // 갤러그 탄알이 화면 상단 일정 부분을 넘어가면 삭제하도록 한다
                {
                    tmp.setInvisible();
                    galagArmoArray.RemoveAt(i);
                }
                else // 갤러그 탄알이 화면 상단 일정 부분을 넘어가지 않은 상태라면
                {
                    for (int j = 0; j < enemyArray.Count; j++) // 모든 적 객체들을 확인해 갤러그 탄알에 피격되었지 안되었는지를 판단하는 반복문
                    {                   
                        Enemy enemy = enemyArray[j] as Enemy;
                        // 적 객체의 히트박스에 갤러그 탄알이 만나면 적 객체를 피격된 것으로 판단
                        if (tmp.armoY < enemy.enemyY && (enemy.enemyX - (enemy.getWidth() / 2) + 30 <= tmp.armoX && tmp.armoX <= (enemy.enemyX + enemy.getWidth() / 2) + 22))
                        {
                            tmp.setInvisible();
                            galagArmoArray.RemoveAt(i); // 적 객체에 피격된 갤러그 탄알은 삭제하고
                            enemy.hitCnt--; // 적 객체의 체력 감소
                            enemy.whenEnemyHit(); // 피격당한 이펙트를 발생

                            if (enemy.hitCnt == 0) // 만약 적 객체의 체력이 전부 소모되면
                            {
                                enemy.setInvisible();
                                score += 10; // score를 10점 추가하고
                                enemyArray.RemoveAt(j); // 적 객체는 삭제한다
                            }
                        }
                    }
                }

                // 보스 객체가 갤러그 탄알에 피격 시 구현
                if (bossAppear == true && tmp.armoY < 200)
                {
                    tmp.setInvisible(); 
                    galagArmoArray.RemoveAt(i); // 보스에게 피격 시 갤러그 탄알 삭제
                    bossHitCnt--; // 보스 객체의 체력 감소
          
                    if (bossHitCnt <= 0) // 보스 객체의 체력이 전부 소모되면
                    {
                        boss.Visible = false; // 보스 객체를 화면에서 제거하고
                        bossAppear = false; // 보스 객체의 등장 상태를 false로 설정
                        score += 1000; // score는 1000점을 추가한다

                        /* 게임을 클리어하였기 때문에 실행하던 모든 타이머들을 중단시키고 화면 상에 남아있던 모든 요소들을 제거한다 */
                        boomMakingTimer.Stop();
                        enemyShootingTimer.Stop();
                        galagShootingTimer.Stop();
                        enemyMakingTimer.Stop();
                        heartMakingTimer.Stop();
                        scoreTimer.Stop();
                        bossShootingTimer.Stop();
                        this.Controls.Clear();
                        gameClear(); // 게임 클리어 시 화면을 구성한다
                    }
                }
                tmp.moveArmo(); // 실질적 갤러그 탄알의 이동을 수행
            }
        }
        
        private void Timer_Tick1(object sender, EventArgs e) //Score 갱신 및 보스 객체 출연 시간을 설정하는 타이머1
        {
            score += 2; // 1초마다 2점씩 점수를 갱신
            scoreLabel.Text = "SCORE: " + score.ToString();          

            if (bossAppear==false) // 보스 객체가 등장하지 않은 동안 보스 객체가 등장하기까지의 시간을 나타내는 bossAppearTime을 증가
                bossAppearTime++;

            if (bossAppearTime == 20) // 설정한 보스 객체의 등장 시간이 되면
            {
                enemyMakingTimer.Stop(); // 적 객체 생성 중지
                enemyShootingTimer.Stop(); // 적 객체의 적 탄알 생성 중지

                /* 기존에 화면에 있던 적 객체, 적의 탄알, 갤러그의 탄알은 삭제하고 보이지 않게 한다 */
                        foreach (Enemy tmp in enemyArray) 
                    tmp.setInvisible();              
                foreach (EnemyArmo tmp in enemyArmoArray)
                    tmp.setInvisible();
                foreach (Armo tmp in galagArmoArray)
                    tmp.setInvisible();
                enemyArray.Clear();
                enemyArmoArray.Clear();
                galagArmoArray.Clear();

                EnableBossShooting(); // 보스 객체의 공격을 시작해주는 타이머7 실행
                bossAppear = true; // 보스 객체의 등장 상태를 true로 만든다
                bossAppearTime = 0; // 보스 객체가 등장했기 때문에 보스 객체의 등장 대기시간 초기화

                bossHP.SizeMode = PictureBoxSizeMode.AutoSize;
                bossHP.Location = new Point(0, 0);

                boss.Parent = this;
                boss.Image = Image.FromFile("C# 리소스파일\\boss.gif");
                boss.SizeMode = PictureBoxSizeMode.AutoSize;
                boss.Location = new Point(0, 50);
            }

            if(bossAppear == true) // 보스 객체가 등장해 있다면 보스 이미지를 화면에 띄워주고 보스 객체의 피격횟수에 따른 보스 객체의 체력바를 업데이트
            {
                bossHP.Parent = this;
                if (bossHitCnt <=5)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP5.png");
                else if(bossHitCnt<=10)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP10.png");
                else if (bossHitCnt <= 15)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP15.png");
                else if (bossHitCnt <= 20)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP20.png");
                else if (bossHitCnt <= 25)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP25.png");
                else if (bossHitCnt <= 30)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP30.png");
                else if (bossHitCnt <= 35)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP35.png");
                else if (bossHitCnt <= 40)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP40.png");
                else if (bossHitCnt <= 45)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP45.png");
                else if (bossHitCnt <= 50)
                    bossHP.Image = Image.FromFile("C# 리소스파일\\bossHP50.png");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
