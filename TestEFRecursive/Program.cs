using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestEFRecursive;
using TestEFRecursive.Entities;

using (DataContext EF = new DataContext())
{
    List<Profile> profiles = EF.listProfiles.Include(p => p.ProfilesShared).ToList();

    foreach (Profile profile in profiles)
    {
        Console.WriteLine(profile.Id);
        Console.WriteLine(profile.LastName);
        Console.WriteLine(profile.FirstName);
        Console.WriteLine(profile.Email);
        foreach(Profile pr in profile.ProfilesShared)
        {

            Console.WriteLine("profile reçu en partage");
            Console.WriteLine(pr.FirstName);
            Console.WriteLine(pr.LastName);
        }
    }
}