using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetID3DataTest
{
    [TestClass]
    public class GetID3DataTest
    {
        [TestMethod]
        public void ItReturnsErrorMessageIfFolderPathIsInvalid()
        {
            //Arrange
            var file = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27\\1. Allegro moderato.MP3";
            var artist = "Alnaes, Eyvind";
            var album = "Piano Concerto in D major, Op 27";

            //Act
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);

            //Assert
            Assert.AreEqual(expected, mp3Folder.IsValid);
        }
    }
}
