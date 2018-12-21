using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaperNS;

namespace PaperNSTest
{
    [TestClass]
    public class PapersTest
    {
        [TestMethod]
        public void Page_IsNotNull_TrueReturned()
        {
            Page page = new Page();

            Assert.IsNotNull(page);
        }

        [TestMethod]
        public void DrawingBook_IsNotNull_TrueReturned()
        {
            DrawingBook drawingBook = new DrawingBook();

            Assert.IsNotNull(drawingBook);
        }

        [TestMethod]
        public void Page_IsEquale_TrueReturned()
        {
            Page page1 = new Page(2, "Белый", true, "", 0, 0);
            Page page2 = new Page();

            page2 = page1;

            Assert.AreEqual(page1, page2);
        }

        [TestMethod]
        public void Page_IsNotEquale_TrueReturned()
        {
            Page page1 = new Page(2, "Белый", true, "", 0, 0);
            Page page2 = new Page(2, "Белый", true, "", 0, 0);

            Assert.AreNotEqual(page1,page2);
        }

        [TestMethod]
        public void DrawingBook_IsEquale_TrueReturned()
        {
            DrawingBook drawingBook1 = new DrawingBook("A4", "Радуга", 2018, 4.56, null, "для рисования");
            DrawingBook drawingBook2 = new DrawingBook();

            drawingBook2 = drawingBook1;

            Assert.AreEqual(drawingBook1, drawingBook2);
        }

        [TestMethod]
        public void DrawingBook_IsNotEquale_TrueReturned()
        {
            DrawingBook drawingBook1 = new DrawingBook("A4", "Радуга", 2018, 4.56, null, "для рисования");
            DrawingBook drawingBook2 = new DrawingBook("A4", "Радуга", 2018, 4.56, null, "для рисования");

            Assert.AreNotEqual(drawingBook1, drawingBook2);
        }
    }
}
