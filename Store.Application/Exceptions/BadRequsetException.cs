using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Exceptions;
public class BadRequsetException(string message) : Exception(message);
