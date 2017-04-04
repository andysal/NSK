namespace Nsk.Data.Hibernate
{
	#region Usings

	using NHibernate;

	#endregion

	public interface ISessionManagementStrategy
	{
		ISession GetSession ();
	}
}