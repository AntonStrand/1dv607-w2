using System.Collections.Generic;
using _1dv607_w2.model;

namespace _1dv607_w2.view
{
  interface IView
  {
    void DisplayMenu();
    MenuAction GetAction();
    Member DisplayAddMember();
    Member GetUpdateMemberInformation();
    Boat GetNewBoatInformation();
    Boat GetUpdatedBoatInformation();

    void DisplayCompactList(ICollection<model.Member> members);
    void DisplayVerboseList(ICollection<model.Member> members);
    void DisplayMember(Member member);
    int GetBoatIndex(Member member);

    int GetDeleteMemberIndex(ICollection<model.Member> members);
    int GetUpdateMemberIndex(ICollection<model.Member> members);
    int GetViewMemberIndex(ICollection<model.Member> members);
    int GetNewBoatOwnerIndex(ICollection<model.Member> members);
    int GetDeleteBoatOwnerIndex(ICollection<model.Member> members);
    int GetUpdateBoatOwnerIndex(ICollection<model.Member> members);
  }
}