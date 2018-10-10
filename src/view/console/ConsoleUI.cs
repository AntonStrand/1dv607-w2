using System;
using System.Collections.Generic;
using _1dv607_w2.model;

namespace _1dv607_w2.view.console
{
  class ConsoleUI : ConsoleBase, IView
  {

    private StartMenu _startMenu;
    private MemberView _memberView;

    private BoatView _boatView;

    public ConsoleUI()
    {
      _startMenu = new StartMenu();
      _memberView = new MemberView();
      _boatView = new BoatView();
    }

    public void DisplayMenu() => _startMenu.DisplayMenu();
    public MenuSelection.Action GetAction() => _startMenu.GetAction();

    public Member DisplayAddMember() => _memberView.DisplayMemberForm("Add member");
    public Member GetUpdateMemberInformation() => _memberView.DisplayMemberForm("Update member");
    public void DisplayMember(Member member) => _memberView.DisplayMember(member);

    public void DisplayCompactList(ICollection<model.Member> members) => _memberView.DisplayCompactList(members);
    public void DisplayVerboseList(ICollection<model.Member> members) => _memberView.DisplayVerboseList(members);

    public int GetDeleteMemberIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("delete", members);
    public int GetUpdateMemberIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("update", members);
    public int GetViewMemberIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("view", members);
    public int GetNewBoatOwnerIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("register a boat to", members);
    public int GetDeleteBoatOwnerIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("delete a boat from", members);
    public int GetUpdateBoatOwnerIndex(ICollection<model.Member> members) => _memberView.DisplayChooseMember("update a boat for", members);


    public int GetBoatIndex(Member member) => _boatView.GetBoatIndex(member);
    public Boat GetNewBoatInformation() => _boatView.GetBoatInformation("Add new boat");
    public Boat GetUpdatedBoatInformation() => _boatView.GetBoatInformation("Update boat");
  }
}
