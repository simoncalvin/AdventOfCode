using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class NotQuiteLispTests
    {
        private NotQuiteLisp _target;

        [TestInitialize]
        public void BeforeEach()
        {
            _target = new NotQuiteLisp();
        }

        [TestMethod]
        public void Should_start_on_zeroth_floor()
        {
            var actual = _target.Solve(string.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Should_go_up_one_floor_for_open_parentheses()
        {
            var input = "(";

            var actual = _target.Solve(input);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Should_go_down_one_floor_for_close_parentheses()
        {
            var input = ")";

            var actual = _target.Solve(input);

            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Should_work_for_very_tall_buildings()
        {
            var input = Enumerable.Range(0, 1000).Aggregate(new StringBuilder(), (a, x) => a.Append("(")).ToString();

            var actual = _target.Solve(input);

            Assert.AreEqual(1000, actual);
        }

        [TestMethod]
        public void Should_work_for_very_deep_basements()
        {
            var input = Enumerable.Range(0, 1000).Aggregate(new StringBuilder(), (a, x) => a.Append(")")).ToString();

            var actual = _target.Solve(input);

            Assert.AreEqual(-1000, actual);
        }

        [TestMethod]
        public void Should_ignore_any_other_characters()
        {
            var input = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789`~!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

            var actual = _target.Solve(input);

            Assert.AreEqual(0, actual);
        }

        // following tests are based on examples from adventofcode.com/day/1

        [TestMethod]
        public void Should_return_zero_for_nested_set()
        {
            var input = "(())";

            var actual = _target.Solve(input);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Should_return_zero_for_two_sets()
        {
            var input = "()()";

            var actual = _target.Solve(input);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Should_return_three_for_three_open()
        {
            var input = "(((";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Should_return_three_for_three_open_with_cancelled_sets()
        {
            var input = "(()(()(";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }

        public void Should_return_three_with_inverted_sets()
        {
            var input = "))(((((";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }

        public void Should_return_negative_one_with_cancelled_set()
        {
            var input = "())";

            var actual = _target.Solve(input);

            Assert.AreEqual(-1, actual);
        }

        public void Should_return_negative_one_with_inverted_sets()
        {
            var input = "))(";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }

        public void Should_return_negative_three_for_three_close()
        {
            var input = ")))";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }


        public void Should_return_negative_three_for_three_close_with_cancelled_sets()
        {
            var input = ")())())";

            var actual = _target.Solve(input);

            Assert.AreEqual(3, actual);
        }

    }
}
