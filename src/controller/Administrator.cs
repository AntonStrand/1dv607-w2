using System.Collections.Generic;
using _1dv607_w2.model;
using _1dv607_w2.view;

namespace _1dv607_w2.controller
{
  class Administrator
  {
    ConsoleUI _view;
    Members _members;

    public Administrator(ConsoleUI v, Members members)
    {
      _view = v;
      _members = members;
    }

    public bool run()
    {
      _view.DisplayActionMenu();

      ConsoleUI.Action action = _view.GetAction();

      switch (action)
      {
        case ConsoleUI.Action.Add:
          AddNewMember();
          return true;

        case ConsoleUI.Action.Update:
          UpdateMember();
          return true;

        case ConsoleUI.Action.Delete:
          DeleteMember();
          return true;

        case ConsoleUI.Action.ViewMember:
          ViewMember();
          return true;

        case ConsoleUI.Action.ListCompact:
          ListCompact();
          return true;

        case ConsoleUI.Action.ListVerbose:
          ListVerbose();
          return true;

        case ConsoleUI.Action.RegisterBoat:
          RegisterNewBoat();
          return true;

        case ConsoleUI.Action.DeleteBoat:
          DeleteBoat();
          return true;
        case ConsoleUI.Action.UpdateBoat:
          UpdateBoat();
          return true;

        case view.ConsoleUI.Action.Quit:
          _members.SaveMembers();
          return false;

        default: return true;
      }
    }

    private void AddNewMember()
    {
      Member member = _view.DisplayAddMember();
      if (member != null) _members.AddMember(member);
    }

    private void DeleteMember()
    {
      int index = _view.GetDeleteMemberIndex(_members.GetMembers());
      if (index != -1) _members.DeleteMemberAt(index);
    }

    private void ViewMember()
    {
      int index = _view.GetViewMemberIndex(_members.GetMembers());
      if (index != -1) _view.DisplayMember(_members.GetMemberAt(index));
    }

    private void UpdateMember()
    {
      int index = _view.GetUpdateMemberIndex(_members.GetMembers());
      if (index != -1)
      {
        Member member = _view.GetUpdateMemberInformation();
        if (member != null) _members.UpdateMemberAt(index, member);
      }
    }

    private void ListCompact() => _view.DisplayCompactList(_members.GetMembers());
    private void ListVerbose() => _view.DisplayVerboseList(_members.GetMembers());

    private void RegisterNewBoat()
    {
      int index = _view.GetNewBoatOwnerIndex(_members.GetMembers());
      if (index != -1)
      {
        Boat boat = _view.GetNewBoatInformation();
        if (boat != null) _members.AddBoatToMemberAt(index, boat);
      }
    }

    private void DeleteBoat()
    {
      int index = _view.GetDeleteBoatOwnerIndex(_members.GetMembers());
      if (index != -1)
      {
        Member member = _members.GetMemberAt(index);
        index = _view.GetBoatIndex(member);
        if (index != -1) _members.DeleteMemberBoatAt(index, member);
      }
    }

    private void UpdateBoat()
    {
      int index = _view.GetDeleteBoatOwnerIndex(_members.GetMembers());
      if (index != -1)
      {
        Member member = _members.GetMemberAt(index);
        index = _view.GetBoatIndex(member);
        if (index != -1)
        {
          Boat boatData = _view.GetUpdatedBoatInformation();
          if (boatData != null) _members.UpdateMemberBoatAt(index, member, boatData);
        }
      }
    }
  }
}
