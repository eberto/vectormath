# vectormath
This code sample is a transpiler from an upper own defined language
called VMath, that supports Vector operations from a high level perspective, 
with the intention to transpile to C Sharp in future stages.

Language specs:

Vector variable definitions:

A = [1, 2, 3, 4]

- Variable identifiers will begin with a letter, followed by letters or digits.
- Assignment operator is '=', and, as usual, will work from right to left.
- Vector definition is bound by '[]' and inside the scalar numbers will be separated by commas.
- Scalar numbers will only be integers, for simplification.

Vector operations:

A + B = will add all the components of vector A to vector B, resulting in a new vector. Both must have the same length.
A - B = will substract all the components of vector A to vector B, resulting in a new vector. Both must have the same length.
A * B = will cross product both vectors, resulting in a new vector.

Only LexicalAnalyzer is implemented for now.
