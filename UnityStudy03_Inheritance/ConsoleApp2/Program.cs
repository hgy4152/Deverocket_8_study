var action1 = Capture();
var action2 = Capture();

action1();
action1();
action2();
action2();

static Action Capture()
{
    int count = 0;
    string name = "수명연장";

    return () => Console.WriteLine(name[count++]);
}