using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            pictureBox1.BackgroundImage = Image.FromFile("../../Images/BackCard.png");
            Engine.Initiaize();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            await Engine.DealAllCards();

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Selectam cartile pentru Player1
            int index = 0;
            Card[] cards = new Card[]
            {
                Engine.cards[Engine.cardsOrder[index]],
                Engine.cards[Engine.cardsOrder[index + 1]],
                Engine.cards[Engine.cardsOrder[index + 2]],
                Engine.cards[Engine.cardsOrder[index + 3]],
                Engine.cards[Engine.cardsOrder[index + 4]],
            };

            // Calculam scorul pentru Player1
            int player1Score = StraightFlush(cards);
            if (player1Score == -1) player1Score = FourOfAKind(cards);
            if (player1Score == -1) player1Score = FullHouse(cards);
            if (player1Score == -1) player1Score = Flush(cards);
            if (player1Score == -1) player1Score = Straight(cards);
            if (player1Score == -1) player1Score = ThreeOfAKind(cards);
            if (player1Score == -1) player1Score = TwoPairsScore(cards);
            if (player1Score == -1) player1Score = PairScore(cards);
            if (player1Score == -1) player1Score = HighCard(cards);

            // Selectam cartile pentru Player2
            index = 5;
            cards[0] = Engine.cards[Engine.cardsOrder[index]];
            cards[1] = Engine.cards[Engine.cardsOrder[index + 1]];
            cards[2] = Engine.cards[Engine.cardsOrder[index + 2]];
            cards[3] = Engine.cards[Engine.cardsOrder[index + 3]];
            cards[4] = Engine.cards[Engine.cardsOrder[index + 4]];

            // Calculam scorul pentru Player2
            int player2Score = StraightFlush(cards);
            if (player2Score == -1) player2Score = FourOfAKind(cards);
            if (player2Score == -1) player2Score = FullHouse(cards);
            if (player2Score == -1) player2Score = Flush(cards);
            if (player2Score == -1) player2Score = Straight(cards);
            if (player2Score == -1) player2Score = ThreeOfAKind(cards);
            if (player2Score == -1) player2Score = TwoPairsScore(cards);
            if (player2Score == -1) player2Score = PairScore(cards);
            if (player2Score == -1) player2Score = HighCard(cards);

            // Verificam cine a castigat
            if (player1Score > player2Score)
                MessageBox.Show($"Player1: {player1Score}{Environment.NewLine}" +
                    $"Player2: {player2Score}", "Player1 has Won!");
            else
                MessageBox.Show($"Player1: {player1Score}{Environment.NewLine}" +
                    $"Player2: {player2Score}", "Player2 has Won!");
        }

        private int HighCard(Card[] cards)
        {
            int n = 5, max = cards[0].Number;

            for (int i = 1; i < n; i++)
                if (cards[i].Number > max)
                {
                    max = cards[i].Number;
                }
            return max;
        }

        private int PairScore(Card[] cards)
        {
            int n = 5;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (cards[i].Number == cards[j].Number)
                    {
                        return 100 + cards[i].Number;
                    }
            return -1;
        }

        private int TwoPairsScore(Card[] cards)
        {
            int n = 5;
            int index1 = -1;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (cards[i].Number == cards[j].Number
                        && (index1 == -1 || cards[i].Number != cards[index1].Number))
                    {
                        if (index1 == -1)
                            index1 = i;
                        else
                            return 200 + cards[i].Number + cards[index1].Number;
                    }
            return -1;
        }

        private int ThreeOfAKind(Card[] cards)
        {
            int n = 5;

            for (int i = 0; i < n - 2; i++)
                for (int j = i + 1; j < n - 1; j++)
                    for (int k = j + 1; k < n; k++)
                        if (cards[i].Number == cards[j].Number
                            && cards[i].Number == cards[k].Number)
                        {
                            return 300 + cards[i].Number;
                        }
            return -1;
        }

        private int Straight(Card[] cards)
        {
            int n = 5;

            // Sortare
            for (int i = 2; i < n; i++)
                for (int j = i - 1; j > 0; j--)
                    if (cards[j].Number < cards[j - 1].Number)
                    {
                        Card temporary = cards[j];
                        cards[j] = cards[j - 1];
                        cards[j - 1] = temporary;
                    }
            // In cazul unui straight cu asul la inceput: Ace 2 3 4 5
            if (cards[n - 1].Number == 14 && cards[0].Number == 2)
            {
                for (int i = n - 2; i >= 0; i--)
                    cards[i + 1] = cards[i];
                cards[0] = new Card(1); // Asul cu valoarea 1, pentru a da bine la calcul
            }

            // Verificam daca numerele sunt consecutive
            for (int i = 1; i < n; i++)
                if (cards[i].Number - 1 != cards[i - 1].Number)
                    return -1;
            return 400 + cards[n - 1].Number;
        }

        private int Flush(Card[] cards)
        {
            int n = 5;
            for (int i = 1; i < n; i++)
                if (cards[i].Suit != cards[0].Suit)
                    return -1;
            return 500 + HighCard(cards);
        }

        private int FullHouse(Card[] cards)
        {
            int n = 5;
            int threeNumber = ThreeOfAKind(cards) - 300;
            if (threeNumber < 0)
                return -1;

            int pairNumber = -1;
            for (int i = 0; i < n; i++)
            {
                if (cards[i].Number == threeNumber)
                    continue;
                if (pairNumber == -1)
                    pairNumber = cards[i].Number;
                else if (cards[i].Number != pairNumber)
                    return -1;
            }
            return 600 + threeNumber * 5 + pairNumber;
        }

        private int FourOfAKind(Card[] cards)
        {
            int n = 5;

            for (int i = 0; i < n - 3; i++)
                for (int j = i + 1; j < n - 2; j++)
                    for (int k = j + 1; k < n - 1; k++)
                        for (int l = k + 1; l < n; l++)
                        {
                            if (cards[i].Number == cards[j].Number
                                && cards[i].Number == cards[k].Number
                                && cards[i].Number == cards[l].Number)
                                return 700 + cards[i].Number;
                        }
            return -1;
        }

        private int StraightFlush(Card[] cards)
        {
            if (Flush(cards) == -1)
                return -1;

            int number = Straight(cards) - 400;
            if (number < 0)
                return -1;
            return 800 + number;
        }

        public PictureBox CreatePictureBoxForNewCard()
        {
            PictureBox card = new PictureBox();
            card.Parent = this;
            card.BackgroundImage = pictureBox1.BackgroundImage;
            card.Location = pictureBox1.Location;
            card.Size = pictureBox1.Size;
            card.BackgroundImageLayout = pictureBox1.BackgroundImageLayout;

            card.BringToFront();
            return card;
        }
    }
}
