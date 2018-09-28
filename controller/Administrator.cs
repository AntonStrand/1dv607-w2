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
        case view.ConsoleGUI.Action.Add:
          AddNewMember();
          return true;
        // case '2': return Action.Update;
        // case '3': return Action.Delete;
         case view.ConsoleGUI.Action.ListCompact: 
          ListCompact();
          return true;
        // case '5': return Action.ListVerbose;
        case view.ConsoleGUI.Action.Quit: return false;
        default: return true;
      }
    }

    private void AddNewMember()
    {
      List<string> newMemberData = _view.DisplayAddMember();
      if (newMemberData.Count > 0)
      {
        _members.AddMember(newMemberData[0], newMemberData[1]);
      }
    }

    private void ListCompact()
    {
      _view.DisplayCompactList(_members.GetMembers());
    }
  }
}
