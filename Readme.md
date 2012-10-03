# ResxDiff

Helps you deal with your growning number of .NET Resource files by quickly showing you the differences and similarities between them as well as performing simple operations on them.

`$ ResxDiffConsole --help`
    
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

      -i, --identicle-values             Finds keys present in both files with
                                         identicle values

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

---

MIT licenced. More features coming soon (hopefully). Pull requests appreciated :)

