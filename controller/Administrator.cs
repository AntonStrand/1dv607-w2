using System.Collections.Generic;

namespace _1dv607_w2.controller
{
  class Administrator
  {
    view.ConsoleGUI _view;
    model.Members _members;

    public Administrator(view.ConsoleGUI v, model.Members members)
    {
      _view = v;
      _members = members;
    }

    public bool run()
    {
      _view.DisplayActionMenu();

      view.ConsoleGUI.Action action = _view.GetAction();

      switch (action)
      {
        case view.ConsoleGUI.Action.Add: AddNewMember(); break;
        // case '2': return Action.Update;
        // case '3': return Action.Delete;
        // case '4': return Action.ListCompact;
        // case '5': return Action.ListVerbose;
        case view.ConsoleGUI.Action.Quit: return false;
        default: return true;
      }
      return true;
    }

    private void AddNewMember()
    {
      List<string> newMemberData = _view.DisplayAddMember();
      if (newMemberData.Count > 0)
      {
        _members.AddMember(newMemberData[0], newMemberData[1]);
      }
    }
  }
}
