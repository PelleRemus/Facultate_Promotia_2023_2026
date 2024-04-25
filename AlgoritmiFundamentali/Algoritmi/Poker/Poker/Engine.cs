using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public static class Engine
    {
        //     Configuratii posibile:
        // one pair - acelasi numar apare de doua ori
        // two pairs - acelasi numar apare de doua ori, doua perechi
        // three of a kind - acelasi numar apare de trei ori
        // straight - in mana, apar cartile in ordine (culoarea nu conteaza)
        // flush - 5 carti de aceeasi culoare
        // full house - one pair + three of a kind
        // four of a kind - acelasi numar apare de 4 ori
        // straight flush - straight + flush

        public static Image[] cardsImages = new Image[]
        {
            Image.FromFile("../../Images/2OfClubs card.png"),       // 0
            Image.FromFile("../../Images/3OfClubs card.png"),       // 1
            Image.FromFile("../../Images/4OfClubs card.png"),
            Image.FromFile("../../Images/5OfClubs card.png"),
            Image.FromFile("../../Images/6OfClubs card.png"),
            Image.FromFile("../../Images/7OfClubs card.png"),
            Image.FromFile("../../Images/8OfClubs card.png"),
            Image.FromFile("../../Images/9OfClubs card.png"),
            Image.FromFile("../../Images/10OfClubs card.png"),
            Image.FromFile("../../Images/JackOfClubs card.png"),
            Image.FromFile("../../Images/QueenOfClubs card.png"),
            Image.FromFile("../../Images/KingOfClubs card.png"),
            Image.FromFile("../../Images/AceOfClubs card.png"),     // 12

            Image.FromFile("../../Images/2OfSpades card.png"),      // 13
            Image.FromFile("../../Images/3OfSpades card.png"),      // 14
            Image.FromFile("../../Images/4OfSpades card.png"),
            Image.FromFile("../../Images/5OfSpades card.png"),
            Image.FromFile("../../Images/6OfSpades card.png"),
            Image.FromFile("../../Images/7OfSpades card.png"),
            Image.FromFile("../../Images/8OfSpades card.png"),
            Image.FromFile("../../Images/9OfSpades card.png"),
            Image.FromFile("../../Images/10OfSpades card.png"),
            Image.FromFile("../../Images/JackOfSpades card.png"),
            Image.FromFile("../../Images/QueenOfSpades card.png"),
            Image.FromFile("../../Images/KingOfSpades card.png"),
            Image.FromFile("../../Images/AceOfSpades card.png"),    // 25

            Image.FromFile("../../Images/2OfHearts card.png"),      // 26
            Image.FromFile("../../Images/3OfHearts card.png"),      // 27
            Image.FromFile("../../Images/4OfHearts card.png"),
            Image.FromFile("../../Images/5OfHearts card.png"),
            Image.FromFile("../../Images/6OfHearts card.png"),
            Image.FromFile("../../Images/7OfHearts card.png"),
            Image.FromFile("../../Images/8OfHearts card.png"),
            Image.FromFile("../../Images/9OfHearts card.png"),
            Image.FromFile("../../Images/10OfHearts card.png"),
            Image.FromFile("../../Images/JackOfHearts card.png"),
            Image.FromFile("../../Images/QueenOfHearts card.png"),
            Image.FromFile("../../Images/KingOfHearts card.png"),
            Image.FromFile("../../Images/AceOfHearts card.png"),    // 38

            Image.FromFile("../../Images/2OfDiamonds card.png"),    // 39
            Image.FromFile("../../Images/3OfDiamonds card.png"),    // 40
            Image.FromFile("../../Images/4OfDiamonds card.png"),
            Image.FromFile("../../Images/5OfDiamonds card.png"),
            Image.FromFile("../../Images/6OfDiamonds card.png"),
            Image.FromFile("../../Images/7OfDiamonds card.png"),
            Image.FromFile("../../Images/8OfDiamonds card.png"),
            Image.FromFile("../../Images/9OfDiamonds card.png"),
            Image.FromFile("../../Images/10OfDiamonds card.png"),
            Image.FromFile("../../Images/JackOfDiamonds card.png"),
            Image.FromFile("../../Images/QueenOfDiamonds card.png"),
            Image.FromFile("../../Images/KingOfDiamonds card.png"),
            Image.FromFile("../../Images/AceOfDiamonds card.png"),  // 51
        };
        public static Random random = new Random();
        public static int n = 52;
        public static int[] cardsOrder;

        public static void Initiaize()
        {
            cardsOrder = new int[n];
            for (int i = 0; i < n; i++)
                cardsOrder[i] = i;
        }

        public static void Shuffle()
        {
            for (int i = 1; i < n; i++)
            {
                int index = random.Next(i);
                Swap(i, index);
            }
        }

        public static void Swap(int i, int j)
        {
            int aux = cardsOrder[i];
            cardsOrder[i] = cardsOrder[j];
            cardsOrder[j] = aux;
        }

        public static async Task DealAllCards()
        {
            Shuffle();

            CardDealingAnimation(Form1.Instance.p1_1, cardsImages[cardsOrder[0]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p1_2, cardsImages[cardsOrder[1]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p1_3, cardsImages[cardsOrder[2]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p1_4, cardsImages[cardsOrder[3]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p1_5, cardsImages[cardsOrder[4]]); await Task.Delay(200);

            CardDealingAnimation(Form1.Instance.p2_1, cardsImages[cardsOrder[5]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p2_2, cardsImages[cardsOrder[6]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p2_3, cardsImages[cardsOrder[7]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p2_4, cardsImages[cardsOrder[8]]); await Task.Delay(200);
            CardDealingAnimation(Form1.Instance.p2_5, cardsImages[cardsOrder[9]]); await Task.Delay(2000);
        }

        public static async Task CardDealingAnimation(PictureBox destination, Image cardImage)
        {
            PictureBox card = Form1.Instance.CreatePictureBoxForNewCard();
            float percent = 30F / Distance(card.Location, destination.Location);

            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(i / 5);
                float x = card.Location.X + percent * (destination.Location.X - card.Location.X);
                float y = card.Location.Y + percent * (destination.Location.Y - card.Location.Y);
                card.Location = new Point((int)x, (int)y);
            }

            destination.BackgroundImage = cardImage;
            Form1.Instance.Controls.Remove(card);
            card.Dispose();
        }

        public static float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
