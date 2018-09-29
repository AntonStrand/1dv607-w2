using System.Collections.Generic;
using _1dv607_w2.model;
using _1dv607_w2.view;

namespace _1dv607_w2.controller
{
  class Administrator
  {
    ConsoleGUI _view;
    Members _members;

    public Administrator(ConsoleGUI v, Members members)
    {
      _view = v;
      _members = members;
    }

    public bool run()
    {
      _view.DisplayActionMenu();

      ConsoleGUI.Action action = _view.GetAction();

      switch (action)
      {
        case ConsoleGUI.Action.Add: AddNewMember();
          return true;

        case ConsoleGUI.Action.Update: UpdateMember();
          return true;

        case ConsoleGUI.Action.Delete: DeleteMember();
          return true;

        case ConsoleGUI.Action.ListCompact: ListCompact();
          return true;

        // case '5': return Action.ListVerbose;
        case view.ConsoleGUI.Action.Quit: _members.SaveMembers();
          return false;

        default: return true;
      }
    }

    private void AddNewMember()
    {
      MemberFormData newMemberData = _view.DisplayAddMember();
      if (newMemberData.IsValid())
      {
        _members.AddMember(newMemberData.Name, newMemberData.Ssn);
      }
    }

    private void DeleteMember()
    {
      int index = _view.DisplayDeleteMember(_members.GetMembers());
      if (index != -1)
      {
        _members.DeleteMemberAt(index);
      }
    }

    private void UpdateMember()
    {
      int index = _view.DisplayUpdateMember(_members.GetMembers());
      if (index != -1)
      {
        MemberFormData newMemberData = _view.DisplayUpdateMember();
        if (newMemberData.IsValid())
        {
          _members.UpdateMemberAt(index, newMemberData.Name, newMemberData.Ssn);
        }
      }
    }

    private void ListCompact() => _view.DisplayCompactList(_members.GetMembers());

  }
}
