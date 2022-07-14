using Microsoft.EntityFrameworkCore;
using TaskManagement.Abstractions.DataAccess;

namespace TaskManagement.DataAccess;
public class ApplicationContext : DbContext, IApplicationContext
{

}
