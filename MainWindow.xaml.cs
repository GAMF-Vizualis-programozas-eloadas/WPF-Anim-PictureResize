using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PictureResize
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// <summary>
	/// Egyszerű méretváltoztató animációt bemutató példaprogram.
	/// Feladat: amikor a felhasználó az egeret a kép vezérlő fölé viszi,
	///          a kép mérete nőjön meg úgy, hogy teljesen kitölkse
	///          a helyörzőként használt keretet. A piros keretvonal csak 
	///          arra szolgál, hogy ellenőrizhetően történjen a méretmódosítás.
	///          Amikor az egér elhagyja a kép vezérlőt egy animáció 
	///          segítségével kicsinyítsük vissza a kép vezérlőt az eredeti
	///          méretére.
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// A kép vezérlő eredeti szélessége.
		/// </summary>
		private double KépSzélesség;
		/// <summary>
		/// A kép vezérlő eredeti magassága.
		/// </summary>
		private double KépMagasság;
		/// <summary>
		/// Az animáció során ennyivel nő a kép vezérlő szélessége.
		/// </summary>
		private double dSz;
		/// <summary>
		/// Az animáció során ennyivel nő a kép vezérlő magassága.
		/// </summary>
		private double dM;
		/// <summary>
		/// Ennyi ideig tart az animáció.
		/// </summary>
		private TimeSpan ts;

		/// <summary>
		/// Konstruktor, adattagok inicializálása.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			// A kép vezérlő eredeti szélessége.
			KépSzélesség = imKép.Width;
			// A kép vezérlő eredeti magassága.
			KépMagasság = imKép.Height;
			// Az animáció során ennyivel nő a kép vezérlő szélessége.
			dSz = 40;
			// Az animáció során ennyivel nő a kép vezérlő magassága.
			dM = 30;
			// Ennyi ideig tart az animáció.
			ts = TimeSpan.FromMilliseconds(500);
		}

		/// <summary>
		/// A felhasználó az egeret a kép vezérlő felé mozgatta.
		/// </summary>
		/// <param name="sender">A kép vezérlő objektum.</param>
		/// <param name="e"></param>
		private void imKép_MouseEnter(object sender, MouseEventArgs e)
		{
			// A vízszintes méretváltoztatást leíró animáció objektum.
			DoubleAnimation da = new DoubleAnimation();
			// Kezdőméret.
			da.From = KépSzélesség;
			// Végső méret.
			da.To = KépSzélesség + dSz;
			// Az animáció időtartama.
			da.Duration = new Duration(ts);
			// A függőleges méretváltoztatást leíró animáció objektum.
			DoubleAnimation db = new DoubleAnimation();
			// Kezdőméret.
			db.From = KépMagasság;
			// Végső méret.
			db.To = KépMagasság + dM;
			// Az animáció időtartama.
			db.Duration = new Duration(ts);
			// A két animáció elindítása.
			imKép.BeginAnimation(WidthProperty, da);
			imKép.BeginAnimation(HeightProperty, db);
		}

		/// <summary>
		/// A felhasználó az egeret elmozgatta a képről.
		/// </summary>
		/// <param name="sender">A kép vezérlő objektum.</param>
		/// <param name="e"></param>
		private void imKép_MouseLeave(object sender, MouseEventArgs e)
		{
			// A vízszintes méretváltoztatást leíró animáció objektum.
			DoubleAnimation da = new DoubleAnimation();
			// Kezdőméret.
			da.From = KépSzélesség + dSz;
			// Végső méret.
			da.To = KépSzélesség;
			// Az animáció időtartama.
			da.Duration = new Duration(ts);

			// A függőleges méretváltoztatást leíró animáció objektum.
			DoubleAnimation db = new DoubleAnimation();
			// Kezdőméret.
			db.From = KépMagasság + dM;
			// Végső méret.
			db.To = KépMagasság;
			// Az animáció időtartama.
			db.Duration = new Duration(ts);

			// A két animáció elindítása.
			imKép.BeginAnimation(WidthProperty, da);
			imKép.BeginAnimation(HeightProperty, db);
		}
	}

}
