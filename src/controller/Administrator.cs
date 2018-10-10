using System.Collections.Generic;
using _1dv607_w2.model;
using _1dv607_w2.view;

namespace _1dv607_w2.controller
{
  class Administrator
  {
    IView _view;
    Members _members;

    public Administrator(IView v, Members members)
    {
      _view = v;
      _members = members;
    }

    public bool run()
    {
      _view.DisplayMenu();

      MenuSelection.Action action = _view.GetAction();

      switch (action)
      {
        case MenuSelection.Action.Add:
          AddNewMember();
          return true;

        case MenuSelection.Action.Update:
          UpdateMember();
          return true;

        case MenuSelection.Action.Delete:
          DeleteMember();
          return true;

        case MenuSelection.Action.ViewMember:
          ViewMember();
          return true;

        case MenuSelection.Action.ListCompact:
          ListCompact();
          return true;

        case MenuSelection.Action.ListVerbose:
          ListVerbose();
          return true;

        case MenuSelection.Action.RegisterBoat:
          RegisterNewBoat();
          return true;

        case MenuSelection.Action.DeleteBoat:
          DeleteBoat();
          return true;
        case MenuSelection.Action.UpdateBoat:
          UpdateBoat();
          return true;

        case MenuSelection.Action.Quit:
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
      int index = _view.GetUpdateBoatOwnerIndex(_members.GetMembers());
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
