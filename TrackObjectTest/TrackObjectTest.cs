using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFUploader;

namespace TrackObjectTest
{
    [TestClass]
    public class TrackObjectTest
    {
        [TestMethod]
        public void TrackObjectSuccessfullyCreatedFromValidMp3File()
        {
            //Arrange
            var originalFileName = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27\\1. Allegro moderato.MP3";

            //Act
            Mp3File file = new Mp3File(originalFileName);
            Track track = new Track(file); 

            //Assert
            Assert.AreEqual(originalFileName, track.TrackPath);
        }

        [TestMethod]
        public void FirstAndLastNamesPopulated()
        {
            //Arrange
            var originalFileName = "D:\\Music_Share\\Music\\Alnaes, Eyvind\\Piano Concerto in D major, Op 27\\1. Allegro moderato.MP3";
            var name = "Alnaes, Eyvind test";
            var firstName = "Eyvind";
            var lastName = "Alnaes";            

            //Act
            Mp3File file = new Mp3File(originalFileName);
            Track track = new Track(file); 

            //Assert
            Assert.AreEqual(firstName, track.composer_first_name);
            Assert.AreEqual(lastName, track.composer_last_name);            
        }
    }
}
