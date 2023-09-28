using NUnit.Framework;

namespace FigureSquary.Test
{
    internal class TestTriangle
    {
        [Test]
        public void Constructor_side_less_0_return_throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, -1, -1));
        }

        [Test]
        public void Constructor_side_equal_0_return_throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, 0));
        }

        [Test]
        public void Square_2_2_2_return_sqrt_3()
        {
            var triangle = new Triangle(2, 2, 2);

            double square = triangle.Square();

            Assert.That(square, Is.EqualTo(Math.Sqrt(3)));
        }

        [Test]
        public void RightAngle_set_input_rightAngle_return_true()
        {
            var triangle = new Triangle(3, 4, 5);

            bool isRightAngled = triangle.RigthAngle();

            Assert.That(isRightAngled, Is.EqualTo(true));
        }

        [Test]
        public void RightAngle_set_input_noRightAngle_return_false()
        {
            var triangle = new Triangle(2, 2, 2);

            bool isRightAngled = triangle.RigthAngle();

            Assert.That(isRightAngled, Is.EqualTo(false));
        }
    }
}
