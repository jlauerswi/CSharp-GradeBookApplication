using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook: BaseGradeBook
    {
        StandardGradeBook(string name) : base(name) {
            Type = GradeBookType.Standard;
        }
    }
}