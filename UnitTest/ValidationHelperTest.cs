using ProjetoLandisGyr.Enums;
using ProjetoLandisGyr.Helpers;

namespace UnitTest
{
    public class ValidationHelperTest
    {
        [Theory (DisplayName = "Pass In \"Yes or No\" Validation")]
        [InlineData("yes")]
        [InlineData("Yes")]
        [InlineData("NO")]
        [InlineData("No")]
        public void PassInYesOrNoValidation(string str)
        {
            var result = ValidationHelper.IsYesOrNo(str);
            Assert.True(result);
        }

        [Fact (DisplayName = "Reject In \"Yes or No\" Validation")]
        public void RejectInYesAndNoValidation()
        {
            var result = ValidationHelper.IsYesOrNo("teste");
            Assert.False(result);
        }

        [Fact(DisplayName = "Pass In \"Is Number\" Validation")]
        public void PassInIsNumberValidation()
        {
            var result = ValidationHelper.IsNumber("5");
            Assert.True(result);
        }

        [Fact(DisplayName = "Reject In \"Is Number\" Validation")]
        public void RejectInIsNumberValidation()
        {
            var result = ValidationHelper.IsNumber("teste");
            Assert.False(result);
        }

        [Theory(DisplayName = "Pass In \"Enum\" Validation")]
        [InlineData("16")]
        [InlineData("17")]
        [InlineData("18")]
        [InlineData("19")]
        public void PassInEnumValidation(string str)
        {
            var result = ValidationHelper.EnumValidation<ModelId>(str);
            Assert.True(result);
        }

        [Fact(DisplayName = "Reject In \"Enum\" Validation")]
        public void RejectInEnumValidation()
        {
            var result = ValidationHelper.EnumValidation<ModelId>("21");
            Assert.False(result);
        }
    }
}