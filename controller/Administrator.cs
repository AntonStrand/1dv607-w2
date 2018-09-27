using System.Collections.Generic;

namespace _1dv607_w2.controller
{
  class Administrator
  {

    public bool run(view.ConsoleGUI v, model.Members members)
    {
      v.DisplayActionMenu();

      view.ConsoleGUI.Action action = v.GetAction();

      switch (action)
      {
        case view.ConsoleGUI.Action.Add:
          List<string> newMemberData = v.DisplayAddMember();
          return true;
        // case '2': return Action.Update;
        // case '3': return Action.Delete;
        // case '4': return Action.ListCompact;
        // case '5': return Action.ListVerbose;
        case view.ConsoleGUI.Action.Quit: return false;
        default: return true;
      }
    }
  }
}
