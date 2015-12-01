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
        public void Traverse_should_start_on_zeroth_floor()
        {
            var actual = _target.Traverse(string.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Traverse_should_go_up_one_floor_for_open_parentheses()
        {
            var directions = "(";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Traverse_should_go_down_one_floor_for_close_parentheses()
        {
            var directions = ")";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Traverse_should_work_for_very_tall_buildings()
        {
            var directions = Enumerable.Range(0, 1000).Aggregate(new StringBuilder(), (a, x) => a.Append("(")).ToString();

            var actual = _target.Traverse(directions);

            Assert.AreEqual(1000, actual);
        }

        [TestMethod]
        public void Traverse_should_work_for_very_deep_basements()
        {
            var directions = Enumerable.Range(0, 1000).Aggregate(new StringBuilder(), (a, x) => a.Append(")")).ToString();

            var actual = _target.Traverse(directions);

            Assert.AreEqual(-1000, actual);
        }

        [TestMethod]
        public void Traverse_should_ignore_any_other_characters()
        {
            var directions = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789`~!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Traverse_should_return_zero_for_nested_set()
        {
            var directions = "(())";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Traverse_should_return_zero_for_two_sets()
        {
            var directions = "()()";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Traverse_should_return_three_for_three_open()
        {
            var directions = "(((";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Traverse_should_return_three_for_three_open_with_cancelled_sets()
        {
            var directions = "(()(()(";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }

        public void Traverse_should_return_three_with_inverted_sets()
        {
            var directions = "))(((((";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }

        public void Traverse_should_return_negative_one_with_cancelled_set()
        {
            var directions = "())";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(-1, actual);
        }

        public void Traverse_should_return_negative_one_with_inverted_sets()
        {
            var directions = "))(";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }

        public void Traverse_should_return_negative_three_for_three_close()
        {
            var directions = ")))";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }


        public void Traverse_should_return_negative_three_for_three_close_with_cancelled_sets()
        {
            var directions = ")())())";

            var actual = _target.Traverse(directions);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void TraverseToBasement_should_return_one_if_first_step_is_down()
        {
            var directions = ")";

            var actual = _target.TraverseToBasement(directions);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void TraverseToBasement_should_return_index_of_first_uncancelled_close()
        {
            var directions = "()())";

            var actual = _target.TraverseToBasement(directions);

            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void TraverseToBasement_should_ignore_any_directions_after_first_basement_entry()
        {
            var directions = "()())(())";

            var actual = _target.TraverseToBasement(directions);

            Assert.AreEqual(5, actual);
        }
    }
}
