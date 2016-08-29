﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGB_Pokemon
{
    class PokemonData
    {
        public static string PokemonById(int id)
        {
            var names = new[]
            {
                "'M",
                "Rhydon",
                "Kangaskhan",
                "Nidoran♂",
                "Clefairy",
                "Spearow",
                "Voltorb",
                "Nidoking",
                "Slowbro",
                "Ivysaur",
                "Exeggutor",
                "Lickitung",
                "Exeggcute",
                "Grimer",
                "Gengar",
                "Nidoran♀",

                "Nidoqueen",
                "Cubone",
                "Rhyhorn",
                "Lapras",
                "Arcanine",
                "Mew",
                "Gyarados",
                "Shellder",
                "Tentacool",
                "Gastly",
                "Scyther",
                "Staryu",
                "Blastoise",
                "Pinsir",
                "Tangela",
                "MissingNo.",

                "MissingNo.",
                "Growlithe",
                "Onix",
                "Fearow",
                "Pidgey",
                "Slowpoke",
                "Kadabra",
                "Graveler",
                "Chansey",
                "Machoke",
                "Mr. Mime",
                "Hitmonlee",
                "Hitmonchan",
                "Arbok",
                "Parasect",
                "Psyduck",

                "Drowzee",
                "Golem",
                "MissingNo.",
                "Magmar",
                "MissingNo.",
                "Electabuzz",
                "Magneton",
                "Koffing",
                "MissingNo.",
                "Mankey",
                "Seel",
                "Diglett",
                "Tauros",
                "MissingNo.",
                "MissingNo.",
                "MissingNo.",

                "Farfetch'd",
                "Venonat",
                "Dragonite",
                "MissingNo.",
                "MissingNo.",
                "MissingNo.",
                "Doduo",
                "Poliwag",
                "Jynx",
                "Moltres",
                "Articuno",
                "Zapdos",
                "Ditto",
                "Meowth",
                "Krabby",
                "MissingNo.",

                "MissingNo.",
                "MissingNo.",
                "Vulpix",
                "Ninetales",
                "Pikachu",
                "Raichu",
                "MissingNo.",
                "MissingNo.",
                "Dratini",
                "Dragonair",
                "Kabuto",
                "Kabutops",
                "Horsea",
                "Seadra",
                "MissingNo.",
                "MissingNo.",

                "Sandshrew",
                "Sandslash",
                "Omanyte",
                "Omastar",
                "Jigglypuff",
                "Wigglytuff",
                "Eevee",
                "Flareon",
                "Jolteon",
                "Vaporeon",
                "Machop",
                "Zubat",
                "Ekans",
                "Paras",
                "Poliwhirl",
                "Poliwrath",

                "Weedle",
                "Kakuna",
                "Beedrill",
                "MissingNo.",
                "Dodrio",
                "Primeape",
                "Dugtrio",
                "Venomoth",
                "Dewgong",
                "MissingNo.",
                "MissingNo.",
                "Caterpie",
                "Metapod",
                "Butterfree",
                "Machamp",
                "MissingNo.",

                "Golduck",
                "Hypno",
                "Golbat",
                "Mewtwo",
                "Snorlax",
                "Magikarp",
                "MissingNo.",
                "MissingNo.",
                "Muk",
                "MissingNo.",
                "Kingler",
                "Cloyster",
                "MissingNo.",
                "Electrode",
                "Clefable",
                "Weezing",

                "Persian",
                "Marowak",
                "MissingNo.",
                "Haunter",
                "Abra",
                "Alakazam",
                "Pidgeotto",
                "Pidgeot",
                "Starmie",
                "Bulbasaur",
                "Venusaur",
                "Tentacruel",
                "MissingNo.",
                "Goldeen",
                "Seaking",
                "MissingNo.",

                "MissingNo.",
                "MissingNo.",
                "MissingNo.",
                "Ponyta",
                "Rapidash",
                "Rattata",
                "Raticate",
                "Nidorino",
                "Nidorina",
                "Geodude",
                "Porygon",
                "Aerodactyl",
                "MissingNo.",
                "Magnemite",
                "MissingNo.",
                "MissingNo.",

                "Charmander",
                "Squirtle",
                "Charmeleon",
                "Wartortle",
                "Charizard",
                "MissingNo.",
                "Kabutops MissingNo.",
                "Aerodactyl MissingNo.",
                "Ghost MissingNo.",
                "Oddish",
                "Gloom",
                "Vileplume",
                "Bellsprout",
                "Weepinbell",
                "Victreebel",
                "A",

                "a",
                "freeze",
                ".4",
                "h POKé",
                "POKéWTRAINER",
                "PkMn",
                "LM4",
                "p T",
                "\"Jacred\"",
                "Youngster",
                "Bug Catcher",
                "Lass",
                "Sailor",
                "Jr. Trainer ♂",
                "Jr. Trainer ♀",
                "Pokémaniac",

                "Super Nerd",
                "Hiker",
                "Biker",
                "Burglar",
                "Engineer",
                "Juggler",
                "Fisherman",
                "Swimmer",
                "Cue Ball",
                "Gambler",
                "Beauty",
                "Psychic",
                "Rocker",
                "Juggler",
                "Tamer",
                "Bird Keeper",

                "Blackbelt",
                "Rival 1",
                "Professor Oak",
                "Chief",
                "Scientist",
                "Giovanni",
                "Rocket",
                "Cooltrainer ♂",
                "Cooltrainer ♀",
                "Bruno",
                "Brock",
                "Misty",
                "Lt. Surge",
                "Erika",
                "Koga",
                "Blaine",

                "Sabrina",
                "Gentleman",
                "Rival 2",
                "Rival 3",
                "Lorelei",
                "Channeler",
                "Agatha",
                "Lance",
                "Glitch",
                "Glitch",
                "Glitch",
                "Glitch Trainer",
                "Glitch Trainer",
                "Glitch Trainer",
                "Glitch Trainer",
                "Glitch Trainer",
            };
            return id < names.Length ? names[id] : null;
        }
        public static string MapById(int id)
        {
            var names = new[]
            {
                "Pallet Town",
                "Viridian City",
                "Pewter City",
                "Cerulean City",
                "Lavender Town",
                "Vermilion City",
                "Celadon City",
                "Fuchsia City",
                "Cinnabar Island",
                "Indigo Plateau",
                "Saffron City",
                null,
                "Route 1",
                "Route 2",
                "Route 3",
                "Route 4",
                "Route 5",

                "Route 6",
                "Route 7",
                "Route 8",
                "Route 9",
                "Route 10",
                "Route 11",
                "Route 12",
                "Route 13",
                "Route 14",
                "Route 15",
                "Route 16",
                "Route 17",
                "Route 18",
                "Route 19",
                "Route 20",
                "Route 21",

                "Route 22",
                "Route 23",
                "Route 24",
                "Route 25",
                "Player's House - 1F",
                "Player's House - 2F",
                "Rival's House",
                "Oak's Lab",
                "Viridian Pokémon Center",
                "Viridian Pokémon Mart",
                "School",
                "Viridian House",
                "Viridian Gym",
                "Digglet's Cave - Route 2",
                "Viridian Forest Exit",
                "Route 2 House",

                "Route 2 Gate",
                "Viridian Forest Entrance",
                "Viridian Forest",
                "Museum - 1F",
                "Museum - 2F",
                "Pewter Gym",
                "Pewter House - North East",
                "Pewter Pokémon Mart",
                "Pewter House - South West",
                "Pewter Pokémon Center",
                "Mt. Moon - F1",
                "Mt. Moon - BF1",
                "Mt. Moon - BF2",
                "Cerulean House - Dig",
                "Cerulean House - West",
                "Cerulean Pokémon Center",

                "Cerulean Gym",
                "Bike Shop",
                "Cerulean Pokémon Mart",
                "Mt. Moon Pokémon Center",
                null,
                "Route 5 Gate",
                "Route 5 Underground",
                "Day Care",
                "Route 6 Gate",
                "Route 6 Underground",
                null,
                "Route 7 Gate",
                "Route 7 Underground",
                null,
                "Route 8 Gate",
                "Route 8 Underground",

                "Rock Tunnel Pokémon Center",
                "Rock Tunnel - 1F",
                "Power Plant",
                "Route 11 Gate - 1F",
                "Digglet's Cave - Route 11",
                "Route 11 Gate - 2F",
                "Route 12 Gate - 1F",
                "Bill's House",
                "Vermilion Pokémon Center",
                "Fan Club",
                "Vermilion Pokémon Mart",
                "Vermilion Gym",
                "Vermilion House - South",
                "Vermilion Dock",
                "SS Anne - 1F",
                "SS Anne - 2F",

                "SS Anne - 3F",
                "SS Anne - B1F",
                "SS Anne - Deck",
                "SS Anne - Kitchen",
                "SS Anne - Captain's Room",
                "SS Anne - 1F Rooms",
                "SS Anne - 2F Rooms",
                "SS Anne - B1F Rooms",
                null,
                null,
                null,
                "Victory Road - 1F",
                null,
                null,
                null,
                null,

                "Lance Room",
                null,
                null,
                null,
                null,
                "Hall of Fame Room",
                "Underground Path - Route 5/6",
                "Rival Room",
                "Underground Path - Route 7/8",
                "Celadon Department Store - 1F",
                "Celadon Department Store - 2F",
                "Celadon Department Store - 3F",
                "Celadon Department Store - 4F",
                "Celadon Department Store - Roof",
                "Celadon Department Store - Elevator",
                "Celadon Mansion - 1F",

                "Celadon Mansion - 2F",
                "Celadon Mansion - 3F",
                "Celadon Mansion - Roof",
                "Celadon Mansion - Room",
                "Celadon Pokémon Center",
                "Celadon Gym",
                "Celadon Game Corner",
                "Celadon Department Store - 5F",
                "Celadon Prize Corner",
                "Celadon Diner",
                "Celadon House",
                "Celadon Hotel",
                "Lavender Pokémon Center",
                "Pokemon Tower - 1F",
                "Pokemon Tower - 2F",
                "Pokemon Tower - 3F",

                "Pokemon Tower - 4F",
                "Pokemon Tower - 5F",
                "Pokemon Tower - 6F",
                "Pokemon Tower - 7F",
                "Lavender House - Middle",
                "Lavender Pokémon Mart",
                "Lavender House - South West",
                "Fuchsia Pokémon Mart",
                "Fuchsia House - South West",
                "Fuchsia Pokémon Center",
                "Fuchsia Warden House",
                "Safari Zone - Entrance",
                "Fuchsia Gym",
                "Fuchsia Meeting Room",
                "Seafoam Islands - B1F",
                "Seafoam Islands - B2F",

                "Seafoam Islands - B3F",
                "Seafoam Islands - B4F",
                "Vermilion House - Old Rod",
                "Fuchsia House - Good Rod",
                "Pokemon Mansion - 1F",
                "Cinnabar Gym",
                "Pokemon Lab - Entrance",
                "Pokemon Lab - Meeting Room",
                "Pokemon Lab - R&D Room",
                "Pokemon Lab - Testing Room",
                "Cinnabar Pokémon Center",
                "Cinnabar Pokémon Mart",
                "Indigo Plateau Lobby",
                "Copycat's House - 1F",
                "Copycat's House - 2F",

                "Fighting Dojo",
                "Saffron Gym",
                "Saffron House - East",
                "Saffron Pokémon Mart",
                "Silph Co. - 1F",
                "Saffron Pokémon Center",
                "Saffron House - South East",
                "Route 15 Gate - 1F",
                "Route 15 Gate - 2F",
                "Route 16 Gate - 1F",
                "Route 16 Gate - 2F",
                "Route 16 House",
                "Route 12 House - Super Rod",
                "Route 18 Gate - 1F",
                "Route 18 Gate - 2F",
                "Seafoam Islands - 1F",

                "Route 22 Gate",
                "Victory Road - 2F",
                "Route 12 Gate - 2F",
                "Vermilion House - Middle",
                "Diglett's Cave",
                "Victory Road - 3F",
                "Rocket Hideout - B1F",
                "Rocket Hideout - B2F",
                "Rocket Hideout - B3F",
                "Rocket Hideout - B4F",
                "Rocket Hideout - Elevator",
                null,
                null,
                null,
                "Silph Co. - 2F",
                "Silph Co. - 3F",

                "Silph Co. - 4F",
                "Silph Co. - 5F",
                "Silph Co. - 6F",
                "Silph Co. - 7F",
                "Silph Co. - 8F",
                "Pokemon Mansion - 2F",
                "Pokemon Mansion - 3F",
                "Pokemon Mansion - B1F",
                "Safari Zone - Area 2",
                "Safari Zone - Area 3",
                "Safari Zone - Area 4",
                "Safari Zone - Area 1",
                "Safari Zone - Area 1 Rest House",
                "Safari Zone - Secret House",
                "Safari Zone - Area 4 Rest House",
                "Safari Zone - Area 2 Rest House",

                "Safari Zone - Area 3 Rest House",
                "Cerulean Cave - 2F",
                "Cerulean Cave - B1F",
                "Cerulean Cave - 1F",
                "Name Rater",
                "Cerulean House - North West",
                null,
                "Rock Tunnel - B1F",
                "Silph Co. - 9F",
                "Silph Co. - 10F",
                "Silph Co. - 11F",
                "Silph Co. - Elevator",
                null,
                null,
                "Battle Center",
                "Trade Center",

                null,
                null,
                null,
                null,
                "Lorelei Room",
                "Bruno Room",
                "Agatha Room",
                "Beach House",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
            };
            return id < names.Length ? names[id] : null;
        }
    }
}