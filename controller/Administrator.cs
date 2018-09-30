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
        case ConsoleGUI.Action.Add:
          AddNewMember();
          return true;

        case ConsoleGUI.Action.Update:
          UpdateMember();
          return true;

        case ConsoleGUI.Action.Delete:
          DeleteMember();
          return true;

        case ConsoleGUI.Action.ListCompact:
          ListCompact();
          return true;

        case ConsoleGUI.Action.ListVerbose:
          ListVerbose();
          return true;

        case ConsoleGUI.Action.RegisterBoat:
          RegisterNewBoat();
          return true;

        case view.ConsoleGUI.Action.Quit:
          _members.SaveMembers();
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
      int index = _view.GetDeleteMemberIndex(_members.GetMembers());
      if (index != -1)
      {
        _members.DeleteMemberAt(index);
      }
    }

    private void UpdateMember()
    {
      int index = _view.GetUpdateMemberIndex(_members.GetMembers());
      if (index != -1)
      {
        MemberFormData newMemberData = _view.GetUpdateMemberIndex();
        if (newMemberData.IsValid())
        {
          _members.UpdateMemberAt(index, newMemberData.Name, newMemberData.Ssn);
        }
      }
    }

    private void ListCompact() => _view.DisplayCompactList(_members.GetMembers());
    private void ListVerbose() => _view.DisplayVerboseList(_members.GetMembers());

    private void RegisterNewBoat()
    {
      int index = _view.GetBoatOwnerIndex(_members.GetMembers());
      if (index != -1)
      {
        // Display Boat form.
        BoatFormData boatData = _view.GetNewBoatInformation();
        if (boatData.isValid())
        {
          _members.AddBoatToMemberAt(index, new Boat(boatData.BoatType, boatData.Length));
        }
        // Send response and member index to _members.
      }
    }
  }
}
