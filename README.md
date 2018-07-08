# Bancud_Exercise02
Data Struct and Algorithms Exercise02

Exercise#2] Create a new
solution <Lastname>_Exercise02 then add new projects for the following
problems.
Exercise02_A] 
(a)
Write a program for keeping a course list for each student in college. The
information about each student should be kept in an object that contains the
student’s name and a list of courses completed by the student. The courses
taken by a student are stored as a linked list in which each node contains the
name of a course, the number of units for the course, and the course grade. The
program gives a menu with choices that include adding a student’s record,
deleting a student’s record, deleting a single course record from a student’s
record, and printing a student’s record to the screen. The program input should
accept the student’s name in any combination of upper- and lowercase letters. A
student’s record should include the student’s GPA (grade point average) when
displayed on the screen. 

(b) When the user is through with the program, the program should store the records in
file. The next time the program is run, the records should be read back out of
the file and the list should be reconstructed.


Exercise02_B] We canrepresent a polynomial as a list of terms, where the terms are in decreasing
order by exponent. You should define a Term
that contains data fields coef and exponent. For example, -5x^4 has a coef
value of -5 and an exponent value of 4. To add two polynomials, you
traverse both lists and examine the two terms at the current iterator position.
If the exponent of one is smaller than the exponent of the other, then insert
the larger one into the result and advance that list’s iterator. If the
exponents are equal, then create a new term with that exponent and the sum of
the two coefficients, and advance both iterators. For example: 3x^4+2x^2+3x+7
added to 2x^3+-5x+5 is 3x^4+2x^3+2x^2+-2x+12.

Write a polynomial class with an inner class Term.
The polynomial class should have a data field terms that is of type LinkedList<Term>. Provide an Addpoly
method and a Readpoly method. Method Readpoly
reads a string representing a polynomial such as "2x^3+-4x^2 " and
returns a polynomial list with two terms. You also need a ToString
method for class Term and Polynomial that would display this stored polynomial
2x^3+-4x^2.

Provide a multiply method for your polynomial class. To multiply, you iterate through
polynomial A and then multiply all terms of polynomial B by the current term of
polynomial A. You then ad each term you get by multiplying two terms to the
polynomial result. For example, 
 is 8x^5
