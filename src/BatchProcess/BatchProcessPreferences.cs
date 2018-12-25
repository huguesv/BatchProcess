// Copyright (c) Hugues Valois. All rights reserved.
// Licensed under the MIT license. See LICENSE in the project root for license information.

namespace Woohoo.BatchProcess
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Application preferences.
    /// </summary>
    public class BatchProcessPreferences
    {
        /// <summary>
        /// Gets or sets absolute path to the executable.
        /// </summary>
        public string Executable { get; set; }

        /// <summary>
        /// Gets or sets command line parameters to pass to the executable.
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether run processes in parallel.
        /// </summary>
        public bool Parallel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether show console window.
        /// </summary>
        public bool ShowWindow { get; set; }

        private static string FilePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), @"Woohoo\Batch Process\Preferences.xml");
            }
        }

        /// <summary>
        /// Load the preferences from the user's application data folder.
        /// </summary>
        /// <returns>Preferences object.</returns>
        public static BatchProcessPreferences Load()
        {
            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(BatchProcessPreferences));
                var prefs = (BatchProcessPreferences)serializer.Deserialize(stream);
                return prefs;
            }
        }

        /// <summary>
        /// Save the preferences to the user's application data folder.
        /// </summary>
        public void Save()
        {
            var prefsFilePath = FilePath;
            Directory.CreateDirectory(Path.GetDirectoryName(prefsFilePath));

            using (var writer = new StreamWriter(prefsFilePath, false, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(BatchProcessPreferences));
                serializer.Serialize(writer, this);
            }
        }
    }
}
