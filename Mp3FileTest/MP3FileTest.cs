using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFUploader;

namespace Mp3FileTest
{

    [TestClass]
    public class MP3FileTest
    {
        [TestMethod]
        public void ItCreatesMp3FolderObjectWithStringArrayOfMp3Files()
        {
            //Arrange
            var folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27";
            var file1 = folder + "\\1. Allegro moderato.MP3";
            var file2 = folder + "\\2. Lento.MP3";
            var file3 = folder + "\\3. Allegro assai.MP3";
            var fileType = "*.mp3";

            //Act
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);

            //Assert
            Assert.AreEqual(file1, mp3Folder.AudioFiles[0]);
            Assert.AreEqual(file2, mp3Folder.AudioFiles[1]);
            Assert.AreEqual(file3, mp3Folder.AudioFiles[2]);
        }

        [TestMethod]
        public void ItReturnsErrorMessageIfFolderPathIsInvalid()
        {
            //Arrange
            var folder = " ";
            var fileType = "*.mp3";
            var expected = false;

            //Act
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);

            //Assert
            Assert.AreEqual(expected, mp3Folder.IsValid);
        }

        [TestMethod]
        public void Mp3FolderObjectContainsOnlyMp3Files()
        {
            //Arrange
            var folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27";
            var fileType = "*.mp3";
            int expected = 3;

            //Act
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);

            //Assert
            Assert.AreEqual(expected, mp3Folder.AudioFiles.Length);
        }

        [TestMethod]
        public void Mp3FolderObjectContainsMp3FilesInSubdirectories()
        {
            //Arrange
            var folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind";
            var fileType = "*.mp3";
            int expected = 3;

            //Act
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);

            //Assert
            Assert.AreEqual(expected, mp3Folder.AudioFiles.Length);
        }

        [TestMethod]
        public void ItCreatesMp3FileWithCorrectFileName()
        {
            //Arrange
            var file = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27\\1. Allegro moderato.MP3";

            //Act
            AudioFile mp3File = new Mp3File(file);

            //Assert
            Assert.AreEqual(mp3File.File.FullName, file);
        }
    }

}
