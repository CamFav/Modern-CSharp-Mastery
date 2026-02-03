using System;
using System.IO;

/*
 * ============================================
 * CONTOSO PETFRIENDS - CONSOLE APPLICATION
 * ============================================
 * CONTEXT:
 *   A simple console-based application used to manage basic information
 *   about pets available for adoption.
 *
 * OBJECTIVES:
 *   - Store pet data using a 2D string array
 *   - Practice loops, conditionals, and user input validation
 *   - Implement menu-driven application logic
 *
 * NOTE:
 *   This is the "classic" implementation following Microsoft Learn
 *   exercises and guidelines.
 */

// ------------------------------------------------------------
// Temporary variables used to build animal records
// ------------------------------------------------------------
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// ------------------------------------------------------------
// Application-level variables
// ------------------------------------------------------------
int maxPets = 8;                 // Maximum number of animals supported
string? readResult;              // Raw user input
string menuSelection = "";       // Menu choice
int petCount = 0;                // Current number of pets in the system
string anotherPet = "y";         // Controls repeated pet entry
bool validEntry = false;         // Input validation flag
int petAge = 0;                  // Parsed numeric age

// ------------------------------------------------------------
// Each row represents one pet
// Columns:
//  0 - ID
//  1 - Species
//  2 - Age
//  3 - Nickname
//  4 - Physical description
//  5 - Personality description
// ------------------------------------------------------------
string[,] ourAnimals = new string[maxPets, 6];

// ------------------------------------------------------------
// Seed initial animal data
// ------------------------------------------------------------
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";

            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    // Store formatted values
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// ------------------------------------------------------------
// Main application loop (menu-driven)
// ------------------------------------------------------------
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower(); 
    }

    // --------------------------------------------------------
    // Process menu selection
    // --------------------------------------------------------
    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;


        // ----------------------------------------------------
        // Other cases (2–8)
        // NOTE:
        // These cases implement user input validation,
        // record updates, and filtering logic.
        // Each case follows the same pattern:
        //   - Skip empty records
        //   - Validate input
        //   - Update array values if needed
        // ----------------------------------------------------
        case "2":
            // Add a new animal friend to the ourAnimals array
            anotherPet = "y";
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // build the animal ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);


                // get a description of the pet's physical appearance - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }

                    validEntry = true;

                } while (validEntry == false);


                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }

                    validEntry = true;

                } while (validEntry == false);


                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                    validEntry = true;

                } while (validEntry == false);

                // store the pet information in the ourAnimals array
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // increment petCount
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }

                string petId = ourAnimals[i, 0].Replace("ID #: ", "").Trim();
                string ageValue = ourAnimals[i, 2].Replace("Age: ", "").Trim();

                if (!int.TryParse(ageValue, out _))
                {
                    int parsedAge;
                    do
                    {
                        Console.WriteLine($"Enter an age for ID #: {petId}");
                        readResult = Console.ReadLine();

                        string input = readResult?.Trim() ?? "";
                        validEntry = int.TryParse(input, out parsedAge);

                        if (validEntry)
                        {
                            ageValue = input;
                        }
                    } while (!validEntry);

                    ourAnimals[i, 2] = "Age: " + parsedAge;
                }

                string petPhysicalDescription = ourAnimals[i, 4].Replace("Physical description: ", "").Trim();

                bool physicalValid =
                   !string.IsNullOrWhiteSpace(petPhysicalDescription) &&
                   !petPhysicalDescription.Contains('\0') &&
                   !petPhysicalDescription.Equals("tbd", StringComparison.OrdinalIgnoreCase);

                if (!physicalValid)
                {
                    validEntry = false;
                    do
                    {
                        Console.WriteLine($"Enter a physical description for ID #: {petId} (size, color, breed, gender, weight, housebroken)");
                        readResult = Console.ReadLine();

                        string input = readResult?.Trim() ?? "";
                        validEntry =
                            !string.IsNullOrWhiteSpace(input) &&
                            !input.Contains('\0') &&
                            !input.Equals("tbd", StringComparison.OrdinalIgnoreCase);

                        if (validEntry)
                        {
                            petPhysicalDescription = input;
                        }
                    } while (!validEntry);


                    ourAnimals[i, 4] = "Physical description: " + petPhysicalDescription;
                }  

            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }

                string petId = ourAnimals[i, 0].Replace("ID #: ", "").Trim();

                string petNickname = ourAnimals[i, 3].Replace("Nickname: ", "").Trim();

                bool nicknameValid =
                   !string.IsNullOrWhiteSpace(petNickname) &&
                   !petNickname.Contains('\0') &&
                   !petNickname.Equals("tbd");

                if (!nicknameValid)
                {
                    do
                    {
                        Console.WriteLine($"Enter a nickname for ID #: {petId}");
                        readResult = Console.ReadLine();

                        string input = readResult?.Trim() ?? "";
                        validEntry =
                            !string.IsNullOrWhiteSpace(input) &&
                            !input.Contains('\0') &&
                            !input.Equals("tbd");

                        if (validEntry)
                        {
                            petNickname = input;
                        }
                    } while (!validEntry);

                    ourAnimals[i, 3] = "Nickname: " + petNickname;
                }

                string petPersonality = ourAnimals[i, 5].Replace("Personality: ", "").Trim();

                bool personalityValid =
                   !string.IsNullOrWhiteSpace(petPersonality) &&
                   !petPersonality.Contains('\0') &&
                   !petPersonality.Equals("tbd", StringComparison.OrdinalIgnoreCase);

                if (!personalityValid)
                {
                    validEntry = false;
                    do
                    {
                        Console.WriteLine($"Enter a personality description for ID #: {petId} (likes or dislikes, tricks, energy level)");
                        readResult = Console.ReadLine();

                        string input = readResult?.Trim() ?? "";
                        validEntry =
                            !string.IsNullOrWhiteSpace(input) &&
                            !input.Contains('\0') &&
                            !input.Equals("tbd", StringComparison.OrdinalIgnoreCase);

                        if (validEntry)
                        {
                            petPersonality = input;
                        }
                    } while (!validEntry);

                    ourAnimals[i, 5] = "Personality: " + petPersonality;
                } 
            }
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            {
                // Edit an animal’s age");

                Console.WriteLine("Enter the ID of the animal you want to edit:");
                readResult = Console.ReadLine();
                string inputId = readResult?.Trim().ToLower() ?? "";

                bool found = false;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "ID #: ")
                    {
                        continue;
                    }

                    string currentId = ourAnimals[i, 0].Replace("ID #: ", "").Trim().ToLower();
                    string ageValue = ourAnimals[i, 2].Replace("Age: ", "").Trim();

                    if (currentId == inputId)
                    {
                        Console.WriteLine($"Current age: {ageValue}");

                        int newAge;

                        do
                        {
                            Console.WriteLine($"Enter a new age for ID #: {currentId}");
                            readResult = Console.ReadLine();
                            string input = readResult?.Trim() ?? "";
                            validEntry = int.TryParse(input, out newAge) && newAge > 0;
                        } while (!validEntry);

                        ourAnimals[i, 2] = "Age: " + newAge;
                        found = true;
                        Console.WriteLine($"Age updated for ID #: {currentId}. New age: {newAge}");
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("ID not found");
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }
        case "6":
            {
                // Edit an animal’s personality description");
                Console.WriteLine("Enter the ID of the animal you want to edit:");
                readResult = Console.ReadLine();
                string inputId = readResult?.Trim().ToLower() ?? "";

                bool found = false;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "ID #: ")
                    {
                        continue;
                    }

                    string currentId = ourAnimals[i, 0].Replace("ID #: ", "").Trim().ToLower();
                    string petPersonality = ourAnimals[i, 5].Replace("Personality: ", "").Trim();

                    if (currentId == inputId)
                    {
                        Console.WriteLine($"Current personality description: {petPersonality}");

                        string newPersonality = "";

                        do
                        {
                            Console.WriteLine($"Enter a new personality description for ID #: {currentId}");
                            readResult = Console.ReadLine();
                            string input = readResult?.Trim() ?? "";
                            validEntry =
                                !string.IsNullOrWhiteSpace(input) &&
                                !input.Contains('\0') &&
                                !input.Equals("tbd", StringComparison.OrdinalIgnoreCase);
                            if (validEntry)
                            {
                                newPersonality = input;
                            }
                        } while (!validEntry);

                        ourAnimals[i, 5] = "Personality: " + newPersonality;
                        found = true;
                        Console.WriteLine($"Personality updated for ID #: {currentId}.");
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("ID not found");
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }
        case "7":
            {
                // Display all cats with a specified characteristic
                Console.WriteLine("Enter a characteristic to search for in cats:");
                readResult = Console.ReadLine();
                string keyword = readResult?.Trim().ToLower() ?? "";

                if (keyword == "")
                {
                    Console.WriteLine("Please enter a non-empty search term.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                }

                bool anyMatch = false;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "ID #: ")
                    {
                        continue;
                    }

                    string species = ourAnimals[i, 1].Replace("Species: ", "").Trim().ToLower();

                    if (species != "cat")
                    {
                        continue;
                    }

                    bool personalityMatch =
                        ourAnimals[i, 5]
                            .Replace("Personality: ", "")
                            .Trim()
                            .ToLower()
                            .Contains(keyword);

                    bool physicalMatch =
                        ourAnimals[i, 4]
                            .Replace("Physical description: ", "")
                            .Trim()
                            .ToLower()
                            .Contains(keyword);

                    if (physicalMatch || personalityMatch)
                    {
                        Console.WriteLine();
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                    }
                }

                if (!anyMatch)
                {
                    Console.WriteLine("No cats found with that characteristic.");
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }
        case "8":
            // Display all dogs with a specified characteristic
            {
                Console.WriteLine("Enter a characteristic to search for in dogs:");
                readResult = Console.ReadLine();
                string keyword = readResult?.Trim().ToLower() ?? "";

                if (keyword == "")
                {
                    Console.WriteLine("Please enter a non-empty search term.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                }

                bool anyMatch = false;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] == "ID #: ")
                    {
                        continue;
                    }

                    string species = ourAnimals[i, 1].Replace("Species: ", "").Trim().ToLower();

                    if (species != "dog")
                    {
                        continue;
                    }

                    bool personalityMatch =
                        ourAnimals[i, 5]
                            .Replace("Personality: ", "")
                            .Trim()
                            .ToLower()
                            .Contains(keyword);

                    bool physicalMatch =
                        ourAnimals[i, 4]
                            .Replace("Physical description: ", "")
                            .Trim()
                            .ToLower()
                            .Contains(keyword);

                    if (physicalMatch || personalityMatch)
                    {
                        Console.WriteLine();
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                    }
                }

                if (!anyMatch)
                {
                    Console.WriteLine("No dogs found with that characteristic.");
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }

        default:
            break;
    }

} while (menuSelection != "exit");
