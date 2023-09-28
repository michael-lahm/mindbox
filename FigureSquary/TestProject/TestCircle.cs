using NUnit.Framework;

namespace FigureSquary.Test
{
    public class TestCircle
    {
        [Test]
        public void Constructor_side_less_0_return_throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }

        [Test]
        public void Constructor_side_equal_0_return_throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
        }

        [Test]
        public void Square_set_input_return_correct_value()
        {
            var circle = new Circle(2);

            double square = circle.Square();

            Assert.That(square, Is.EqualTo(Math.PI * 2 * 2));
        }
    }
}