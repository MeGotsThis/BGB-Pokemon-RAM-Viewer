using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BGB_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private BGBPokemon bgb;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                bgb = new BGBPokemon();
            }
            catch(Exception)
            {
                bgb = null;
            }

            Update();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 60);
            dispatcherTimer.Start();

            refreshRate.SelectedIndex = 1;

            slot0.IsChecked = true;
            slot1.IsChecked = true;
            slot2.IsChecked = true;
            slot3.IsChecked = true;
            slot4.IsChecked = true;
            slot5.IsChecked = true;
            slot6.IsChecked = true;
            slot7.IsChecked = true;
            slot8.IsChecked = true;
            slot9.IsChecked = true;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (bgb == null || bgb.Memory.Process.HasExited)
            {
                try
                {
                    var bgbpokemon = new BGBPokemon();
                    if (DateTime.Now - bgbpokemon.Memory.Process.StartTime > new TimeSpan(0, 0, 0, 0, 500))
                    {
                        // This ensures that bgb is loaded correctly first
                        // Finding a better condition would be nice
                        bgb = bgbpokemon;
                    }
                }
                catch (Exception)
                {
                    if (bgb == null)
                    {
                        process.Content = "BGB Not Found";
                    }
                    else
                    {
                        process.Content = "BGB Closed";
                    }
                    return;
                }
            }
            if (bgb == null)
            {
                return;
            }
            process.Content = "Process ID " + bgb.Memory.Process.Id;

            var inBattle = bgb.InBattle;
            battle.Foreground = inBattle ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Black);
            battle.FontWeight = inBattle ? FontWeights.Bold : FontWeights.Normal;
            var pokemonId = bgb.BattlePokemonId;
            var level = bgb.BattleLevel;
            battle_pokemon.Content = level == 0 && pokemonId == 0 ? "No PKMN Yet" : level == 0 && pokemonId == 255 ? "RESET" : PokemonData.PokemonById(pokemonId);
            battle_level.Content = bgb.BattleLevel;

            int dvs = bgb.BattleDVs;
            int attack =  dvs >> 12 & 0xF;
            int defense = dvs >>  8 & 0xF;
            int speed =   dvs >>  4 & 0xF;
            int special = dvs >>  0 & 0xF;
            int hp = ((attack & 0x1) << 3) | (defense & 0x1) << 2 | (speed & 0x1) << 1 | (special & 0x1);
            battle_hex_dv.Content = dvs.ToString("X4");
            battle_attack.Content = attack;
            battle_defense.Content = defense;
            battle_speed.Content = speed;
            battle_special.Content = special;
            battle_hp.Content = hp;

            var mapId = bgb.MapId;
            var position = bgb.MapPosition;
            overworld_mapid.Content = mapId;
            overworld_mapname.Content = PokemonData.MapById(mapId);
            overworld_x.Content = position.X;
            overworld_y.Content = position.Y;
            var encounterRate = bgb.EncounterRate;
            overworld_encounter_rate.Content = bgb.EncounterRate;

            overworld_time.Content = string.Format("{0}:{1:D2}:{2:D2}.{3:D2}", bgb.Hour, bgb.Minute, bgb.Seconds, bgb.Frames);

            var add = bgb.HRandomAdd;
            var sub = bgb.HRandomSub;
            var sum = (add + sub) & 0xFF;
            rng_hRanAdd.Content = add.ToString("X2");
            rng_hRanSub.Content = sub.ToString("X2");
            rng_dsum.Content = sum.ToString("X2");
            rng_hRanAdd.Foreground = !inBattle && add < encounterRate ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
            rng_hRanAdd.FontWeight = !inBattle && add < encounterRate ? FontWeights.Bold : FontWeights.Normal;

            var slots = new[]
            {
                new { CheckBox = slot0, Rate = slot0Enc, Low = 0x00, High = 0x32, },
                new { CheckBox = slot1, Rate = slot1Enc, Low = 0x33, High = 0x65, },
                new { CheckBox = slot2, Rate = slot2Enc, Low = 0x66, High = 0x8C, },
                new { CheckBox = slot3, Rate = slot3Enc, Low = 0x8D, High = 0xA5, },
                new { CheckBox = slot4, Rate = slot4Enc, Low = 0xA6, High = 0xBE, },
                new { CheckBox = slot5, Rate = slot5Enc, Low = 0xBF, High = 0xD7, },
                new { CheckBox = slot6, Rate = slot6Enc, Low = 0xD8, High = 0xE4, },
                new { CheckBox = slot7, Rate = slot7Enc, Low = 0xE5, High = 0xF1, },
                new { CheckBox = slot8, Rate = slot8Enc, Low = 0xF2, High = 0xFC, },
                new { CheckBox = slot9, Rate = slot9Enc, Low = 0xFD, High = 0xFF, },
            };
            bool subEnc = false;
            var low = (sum - encounterRate + 1) & 0xFF;
            var high = sum;
            foreach (var slot in slots)
            {
                if (slot.CheckBox.IsChecked == true)
                {
                    subEnc = (slot.Low <= sub && sub <= slot.High);
                }
                slot.Rate.Content = "--%";
                slot.Rate.Foreground = new SolidColorBrush(Colors.Black);
                slot.Rate.FontWeight = FontWeights.Normal;
                if (!inBattle && encounterRate > 0 && slot.CheckBox.IsChecked == true)
                {
                    var compare = new[]
                    {
                        new { Low = low, High = high }
                    };
                    if (low > high)
                    {
                        compare = new[]
                        {
                            new { Low = 0, High = high },
                            new { Low = low, High = 0xFF },
                        };
                    }
                    foreach(var c in compare)
                    {
                        if (slot.Low <= c.Low && c.High <= slot.High && compare.Length == 1)
                        {
                            // This is for the large slots who is bigger than the encounter rate
                            slot.Rate.Content = "100%";
                            slot.Rate.Foreground = new SolidColorBrush(Colors.Green);
                            slot.Rate.FontWeight = FontWeights.Bold;
                        }
                        else if (c.Low <= slot.Low && slot.High <= c.High)
                        {
                            // This is for the small slots who is smaller than the encounter rate
                            slot.Rate.Content = string.Format("{0:F1}%", (slot.High - slot.Low + 1.0) / encounterRate * 100);
                            slot.Rate.Foreground = new SolidColorBrush(Colors.Blue);
                            slot.Rate.FontWeight = FontWeights.Bold;
                        }
                        else if (c.Low <= slot.Low && slot.Low <= c.High)
                        {
                            // Exiting the encounter slot
                            slot.Rate.Content = string.Format("{0:F1}%", (high - slot.Low + 1.0) / encounterRate * 100);
                            slot.Rate.Foreground = new SolidColorBrush(Colors.Red);
                            slot.Rate.FontWeight = FontWeights.Bold;
                        }
                        else if (c.Low <= slot.High && slot.High <= c.High)
                        {
                            // Entering the encounter slot
                            slot.Rate.Content = string.Format("{0:F1}%", (slot.High - low + 1.0) / encounterRate * 100);
                            slot.Rate.Foreground = new SolidColorBrush(Colors.Orange);
                            slot.Rate.FontWeight = FontWeights.Bold;
                        }
                    }
                }
            }
            rng_hRanSub.Foreground = !inBattle && subEnc ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
            rng_hRanSub.FontWeight = !inBattle && subEnc ? FontWeights.Bold : FontWeights.Normal;
        }

        private void refreshRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dispatcherTimer == null)
            {
                return;
            }
            if(refreshRate.SelectedIndex == -1 || refreshRate.SelectedIndex == 0)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 120);
            }
            if (refreshRate.SelectedIndex == 1)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 60);
            }
            if (refreshRate.SelectedIndex == 2)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 30);
            }
            if (refreshRate.SelectedIndex == 3)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 20);
            }
            if (refreshRate.SelectedIndex == 4)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 15);
            }
            if (refreshRate.SelectedIndex == 5)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 10);
            }
            if (refreshRate.SelectedIndex == 6)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 5);
            }
            if (refreshRate.SelectedIndex == 7)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 4);
            }
            if (refreshRate.SelectedIndex == 8)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 3);
            }
            if (refreshRate.SelectedIndex == 9)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / 2);
            }
            if (refreshRate.SelectedIndex == 10)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond);
            }
            if (refreshRate.SelectedIndex == 11)
            {
                dispatcherTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond * 2);
            }
        }
    }
}
