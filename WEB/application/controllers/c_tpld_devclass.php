<?php
	 class C_tpld_devclass extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_DEVCLASS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_DEVCLASS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_devclassid' =>  $this->input->get_post('tpld_devclassid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
            $tpld_devclass = $this->m_tpld_devclass->setRow($data);
            print json_encode($tpld_devclass);
    }
    function newRow() {
            log_message('debug', 'TPLD_DEVCLASS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_devclassid' =>  $this->input->get_post('tpld_devclassid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_devclass= $this->m_tpld_devclass->newRow($instanceid,$data);
            $return = $tpld_devclass;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_DEVCLASS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_devclass = $this->m_tpld_devclass->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_devclass
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_devclass= $this->m_tpld_devclass->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_devclass= $this->m_tpld_devclass->getRows($sort);
                }
            }else{
              $tpld_devclass= $this->m_tpld_devclass->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_devclass
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_DEVCLASS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_devclass= $this->m_tpld_devclass->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_devclass
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLD_DEVCLASS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_devclass= $this->m_tpld_devclass->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_devclass
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLD_DEVCLASS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_devclassid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_devclass->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpld_devclass', 'm_tpld_devclass');
    }
}
?>