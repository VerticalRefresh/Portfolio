using SQLite;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Barham_C971.DataClasses
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public AsyncTableQuery<T> Table<T>() where T : new() => _database.Table<T>();
        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Term>();
            await _database.CreateTableAsync<Course>();
            await _database.CreateTableAsync<Instructor>();
            await _database.CreateTableAsync<Assessment>();
            await _database.CreateTableAsync<Student>();
            var termCount = await _database.Table<Term>().CountAsync();

            if (termCount == 0)
            {
                await SeedDataAsync();
            }
        }

        public async Task SeedDataAsync()
        {
            var student = new Student
            {
                StudentName = "Test",
                StudentPassword = "Test"
            };
            await _database.InsertAsync(student);

            var studentID = student.StudentID;

            var term = new Term
            {
                TermName = "January 2026",
                TermStartDate = new DateTime(2026, 1, 1),
                TermEndDate = new DateTime(2026, 6, 30),
                StudentID = studentID
            };
            Debug.WriteLine($"Term ID: {$"Student ID: {term.StudentID} for term {term.TermName}"}");
            await _database.InsertAsync(term);

            var instructor = new Instructor
            {
                InstructorName = "Anika Patel",
                InstructorEmail = "anika.patel@strimeuniversity.edu",
                InstructorPhone = "(555)123-4567"
            };
            await _database.InsertAsync(instructor);

            var course = new Course
            {

                CourseName = "Course 1",
                CourseStatus = "Registered",
                CourseNotes = "Course Notes for Course 1",
                CourseDetails = "Course Details for Course 1",
                CourseStartDate = new DateTime(2026, 1, 1),
                CourseEndDate = new DateTime(2026, 3, 1),
                InstructorID = instructor.InstructorID,
                TermID = term.TermID
            };
            await _database.InsertAsync(course);

            var assessment = new Assessment
            {
                AssessmentName = "Assessment 1",
                AssessmentType = "Objective",
                AssessmentStartDate = new DateTime(2026, 2, 25),
                AssessmentEndDate = new DateTime(2026, 2, 28),
                AssessmentStatus = "Not Started",
                AssessmentNotes = "Assessment 1 details.",
                CourseID = course.CourseID
            };
            await _database.InsertAsync(assessment);

            assessment = new Assessment
            {
                AssessmentName = "Assessment 2",
                AssessmentType = "Practical",
                AssessmentStartDate = new DateTime(2026, 2, 25),
                AssessmentEndDate = new DateTime(2026, 2, 28),
                AssessmentStatus = "Not Started",
                AssessmentNotes = "Assessment 2 details.",
                CourseID = course.CourseID
            };
            await _database.InsertAsync(assessment);

            term = new Term
            {
                TermName = "July 2026",
                TermStartDate = new DateTime(2026, 7, 1),
                TermEndDate = new DateTime(2026, 12, 31),
                StudentID = studentID
            };
            await _database.InsertAsync(term);
            
            instructor = new Instructor
            {
                InstructorName = "John Smith",
                InstructorEmail = "john.smith@strimeuniversity.edu",
                InstructorPhone = "(555)987-6543"
            };
            await _database.InsertAsync(instructor);

            course = new Course
            {
                CourseName = "Course 2",
                CourseStatus = "Not Registered",
                CourseNotes = "Course Notes for Course 2",
                CourseDetails = "Course Details for Course 2",
                CourseStartDate = new DateTime(2026, 7, 1),
                CourseEndDate = new DateTime(2026, 9, 1),
                InstructorID = instructor.InstructorID,
                TermID = term.TermID
            };
            await _database.InsertAsync(course);

            assessment = new Assessment
            {
                AssessmentName = "Assessment 2",
                AssessmentType = "Performance",
                AssessmentStartDate = new DateTime(2026, 8, 25),
                AssessmentEndDate = new DateTime(2026, 8, 28),
                AssessmentStatus = "Not Started",
                AssessmentNotes = "Assessment 2 details.",
                CourseID = course.CourseID
            };
            await _database.InsertAsync(assessment);
        }

        public async Task<List<Term>> GetTermsForStudentAsync(int studentID)
        {
            return await _database.Table<Term>()
                .Where(t => t.StudentID == studentID)
                .ToListAsync();
        }

        public async Task<Term> GetTermAsync(int termID)
        {
            return await _database.Table<Term>().Where(t => t.TermID == termID).FirstOrDefaultAsync();
        }

        public async Task<ObservableCollection<Course>> GetCoursesForTermAsync(int termID)
        {
            var list = await _database
                .Table<Course>()
                .Where(c => c.TermID == termID)
                .ToListAsync();
            return new ObservableCollection<Course>(list);
        }

        public async Task<Course> GetCourseAsync(int courseID)
        {
            return await _database.Table<Course>().Where(c => c.CourseID == courseID).FirstOrDefaultAsync();
        }
        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            return await _database.Table<Instructor>().ToListAsync();
        }

        public async Task<Instructor> GetInstructorAsync(int instructorID)
        {
            return await _database.Table<Instructor>().Where(i => i.InstructorID == instructorID).FirstOrDefaultAsync();
        }
        public async Task<List<Assessment>> GetAssessmentsAsync()
        {
            return await _database.Table<Assessment>().ToListAsync();
        }

        public async Task<List<Assessment>> GetAssessmentsByCourseIdAsync(int courseID)
        {
            return await _database.Table<Assessment>().Where(a => a.CourseID == courseID).ToListAsync();
        }

        public async Task<Assessment> GetAssessmentAsync(int assessmentID)
        {
            return await _database.Table<Assessment>().Where(a => a.AssessmentID == assessmentID).FirstOrDefaultAsync();
        }

        public Task<List<Instructor>> GetAllInstructorsAsync() => _database.Table<Instructor>().ToListAsync();
        public Task<int> InsertTermAsync(Term term)
        {
            return _database.InsertAsync(term);
        }

        public Task<int> InsertCourseAsync(Course course)
        {
            return _database.InsertAsync(course);
        }

        public Task<int> InsertInstructorAsync(Instructor instructor)
        {
            return _database.InsertAsync(instructor);
        }

        public Task<int> InsertAssessmentAsync(Assessment assessment)
        {
            return _database.InsertAsync(assessment);
        }

        public Task<int> UpdateCourseAsync(Course course)
        {
            return _database.UpdateAsync(course);
        }

        public Task<int> UpdateTermAsync(Term term)
        {
            return _database.UpdateAsync(term);
        }

        public Task<int> DeleteTermAsync(Term term)
        {
            return _database.DeleteAsync(term);
        }

        public Task<int> DeleteCourseAsync(Course course)
        {
            return _database.DeleteAsync(course);
        }
        public Task<int> UpdateAssessmentAsync(Assessment assessment)
        {
            return _database.UpdateAsync(assessment);
        }

        public Task<int> DeleteAssessmentAsync(Assessment assessment)
        {
            return _database.DeleteAsync(assessment);
        }

        public Task<int> UpdateInstructorAsync(Instructor instructor)
        {
            return _database.UpdateAsync(instructor);
        }
        public Task<int> DeleteInstructorAsync(Instructor instructor)
        {
            return _database.DeleteAsync(instructor);
        }
    }
}
