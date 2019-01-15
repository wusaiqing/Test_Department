import static org.junit.Assert.*;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Ignore;
import org.junit.Test;


public class TestMyCalus {
	 private static MyCaus calculator = new MyCaus();
	@BeforeClass
	public static void setUpBeforeClass() throws Exception {
		
	}

	@AfterClass
	public static void tearDownAfterClass() throws Exception {
	}

	@Before
	public void setUp() throws Exception {
		 calculator.clear();
	}

	@After
	public void tearDown() throws Exception {
	}

	@Test
	public void testAdd() {
		  calculator.add(2);
	        calculator.add(3);
	        assertEquals(5, calculator.getResult());

	}

	@Test
	public void testSubstract() {
	    calculator.add(10);
        calculator.substract(2);
        assertEquals(8, calculator.getResult());

	}

	
    //@Ignore("Multiply() Not yet implemented")
	@Test
	public void testMultiply() {
		calculator.add(10);
        calculator.multiply(9);
        assertEquals(90, calculator.getResult());
	}

	@Test
	public void testDivide() {
		  calculator.add(8);
	        calculator.divide(2);
	        assertEquals(4, calculator.getResult());

	}

	@Test
	public void testSquare() {
		calculator.square(5);
		assertEquals(25, calculator.getResult());
	}
	
	
	@Ignore("Multiply() Not yet implemented")
	@Test
	public void testSquareRoot() {
		fail("Not yet implemented");
	}

}
