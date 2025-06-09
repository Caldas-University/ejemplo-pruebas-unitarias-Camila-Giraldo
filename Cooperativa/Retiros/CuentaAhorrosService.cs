using System;
using System.Threading;

namespace Cooperativa.Retiros;
public class CuentaAhorrosService
{
    public bool ValidarRetiro(bool activa, decimal saldo, decimal limiteDiario, bool bloqueada, decimal monto)
    {

        if (monto > saldo) return false;
        if (!activa) return false;
        if (monto > limiteDiario) return false;
        if (bloqueada) return false;
        if (monto % 10 != 0) return false;
        return true;
    }
}