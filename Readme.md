# ResxDiff

Helps you deal with your growing number of .NET Resource files by quickly showing you the differences and similarities between them as well as performing simple operations on them.

## Installing

You can install ResxDiff via the [Chocolatey package manager](http://chocolatey.org/packages/resxdiff).

`C:\> cinst resxdiff`

Or build it yourself (scroll down for build instructions).

## Usage

`$ ResxDiff --help`
    
    ResxDiff 0.1
    Copyright (C) 2012 Tom Wadley
    Usage: ResxDiff [OPTION]... [FILE]
    Usage: ResxDiff [OPTION]... [FILE1] [FILE2]
    Usage: ResxDiff [OPTION]... [FILE]...
    Displays information about .resx files, shows differences between .resx files
    and performs operations on .resx files
    
      -m, --missing-keys                 Finds keys present in the first file which
                                         are missing in the second

      -p, --present-keys                 Finds keys that are present in both the
                                         first and the second file

      -d, --different-values             Finds keys present in both files whos
                                         values differ

      -i, --identical-values             Finds keys present in both files with
                                         identical values

      -s, --mismatched-metadata          Finds keys present in both files which
                                         have differing metadata (type, mimetype,
                                         space or comment)

      -u, --duplicate-keys               Finds keys that appear more than once

      -e, --missing-spacepreserve        Finds keys that are missing the
                                         xml:space="preserve" attribute

      -c, --copy-missing-keys            Copies missing keys from the first file to
                                         the second

      -v, --copy-different-values        Copies differing values from the first
                                         file to the second

      -a, --alphabetise                  Sorts keys into alphabetical order

      -r, --add-missing-spacepreserve    Adds xml:space="preserve" attributes to
                                         keys that don't have it

      -f, --full-data                    Shows all fields from the data elements

      --help                             Display this help screen.

## Build instructions

This is using a VS2010 solution file. Dependencies are installed via NuGet. Package restore has been enabled for this solution. That means that in order to build, you have to be running a recent version of NuGet and have "Allow NuGet to download missing packages during build" enabled in the settings as shown [here](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages).

Note: if you having trouble upgrading NuGet, see [this](http://docs.nuget.org/docs/reference/known-issues#Upgrading_to_latest_NuGet_from_an_older_version_causes_a_signature_verification_error.)

After the dependencies have been downloaded by NuGet, it should build. Run the exe in place or put it somewhere in your path for convenient access.

---

MIT licenced. Pull requests appreciated :)

