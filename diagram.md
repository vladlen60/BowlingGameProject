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
