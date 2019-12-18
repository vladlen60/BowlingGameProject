# BowlingGameProject
for evaluation test

# Developer Evaluation Project
Please create a library in either C# or JavaScript keep score in a game of bowling. Write a program to score a game of Ten-Pin Bowling.

**Input:** string (described below) representing a bowling game

**Output:** integer score

**The scoring rules**
Each game, or "line" of bowling, includes ten turns, or "frames" for the bowler.
In each frame, the bowler gets up to two tries to knock down all ten pins.
If the first ball in a frame knocks down all ten pins, this is called a "strike". The frame is over. The score
for the frame is ten plus the total of the pins knocked down in the next two balls.
If the second ball in a frame knocks down all ten pins, this is called a "spare". The frame is over. The score for the frame is ten plus the number of pins knocked down in the next ball.
If, after both balls, there is still at least one of the ten pins standing the score for that frame is simply
the total number of pins knocked down in those two balls.
If you get a spare in the last (10th) frame you get one more bonus ball. If you get a strike in the last (10th) frame you get two more bonus balls.
These bonus throws are taken as part of the same turn. If a bonus ball knocks down all the pins, the process does not repeat. The bonus balls are only used to calculate the score of the final frame.
The game score is the total of all frame scores.



**Examples**

X indicates a strike

/ indicates a spare

'-' indicates a miss

| indicates a frame boundary

The characters after the || indicate bonus balls

**---**

X|X|X|X|X|X|X|X|X|X||XX
Ten strikes on the first ball of all ten frames.
Two bonus balls, both strikes.
Score for each frame == 10 + score for next two balls == 10 + 10 + 10 == 30
Total score == 10 frames x 30 == 300

**---**

9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||
Nine pins hit on the first ball of all ten frames.
Second ball of each frame misses last remaining pin.
No bonus balls.
Score for each frame == 9
Total score == 10 frames x 9 == 90

**---**

5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5
Five pins on the first ball of all ten frames.
Second ball of each frame hits all five remaining pins, a spare.
One bonus ball, hits five pins.
Score for each frame == 10 + score for next one
ball == 10 + 5 == 15
Total score == 10 frames x 15 == 150

**---**

X|7/|9-|X|-8|8/|-6|X|X|X||81
Total score == 167

**---**

**---**


# Assumptions and Decissions

**For Users:**
The program is to calculate the total score for the bowling game. At this moment it's only for the Ten-Pins game, but could be expanded lather to other types of bowling games (like five-pins, nine-pins etc.).
The input at this moment is always a string that represents all throws for the game played and the bonuses (if applicable). The input is expected to be in the certain format:
 - each frame is separated with '|' char;
 - last frame in the game has '||' at the end of it (and before the bonus data);
 - defined characters are used to indicate different throws types ('X' - Strike, '/' - Spare, '-' - miss);
 - no spaces are allowed inside the input string;
Each Bonus-throw start with the original starting 10-pins.
The Loggin part would be developed separatly.
The following white-spaces will be removed: leading and trailing for the whole input, before the Bonus-part, trailing for the Frames-part.


**For Devs:**
Assumes that all bowling games types will require following parameters: Maximum Frames Number, Starting Pins Number, Frames List.
A CommonGameData.cs class should be use to define parameters common for ddifferent bowling games (but with different values).

The End-user will use only .ShowScore() method. The 3rd party apps also will mostly be using the same .ShowScore() method. Thus most of the logic and methods are hidden from the outside users.

**The following diagram shows the flow of the program:**

https://github.com/vladlen60/BowlingGameProject/blob/master/diagram.png

```flow
st=>start: Program.cs
io1=>inputoutput: gameInput
op1=>operation: ShowScore(gameInput)
op2=>operation: ProcessGameData(gameInput, Frames, MaxFramesNumber, StartingPinsNumber)
op3=>operation: CaclulateScore(StartingPinsNumber)
op4=>operation: GameParser
op5=>operation: GameRepo
op6=>operation: FrameRepo

sub1=>subroutine: SplitGameInputString
sub2=>subroutine: NormalFrames
sub3=>subroutine: BonusSthrow
sub4=>subroutine: SplitFramesString()
sub5=>subroutine: BuildAllFramesForTheGame()
sub6=>subroutine: AddBonusToLastFrame
sub7=>subroutine: ProcessFrameStringIntoFrameProperties
sub8=>subroutine: SetFlagsOnFrame

parser=>condition: GoToParser|continue:
frametypes=>condition: NormalFrames
    & Bonuses
frameslistdone=>condition: FramesListDone    
isbonus=>condition: IsBonusAvailable?|bonuse:

io2=>inputoutput: ScoreOutput
e=>end: End

st->io1->op1->op2->parser
parser(yes, right)->op4->frametypes
parser(no, continue)->op3
frametypes(yes)->sub2->sub4
frametypes(no, right)->sub3->sub4
sub4->op5->sub5->frameslistdone
frameslistdone(yes)->op6
frameslistdone(no)->isbonus(left)
isbonus(yes)->sub6->op6
isbonus(no, left)->op6
op6->sub7->sub8(left)->op3
op3->io2->e
```

